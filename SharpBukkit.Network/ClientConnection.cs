using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using Serilog;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Crypto;
using SharpBukkit.Packet.Handshaking;
using SharpBukkit.Packet.Login;
using SharpBukkit.Packet.Status;

namespace SharpBukkit.Network;

public class ClientConnection : IClientConnection {
	public delegate IClientConnection Factory(TcpClient client);

	public EndPoint Endpoint { get; }
	public event Action? OnDisconnect;

	// Injected
	private readonly IServer _server;
	private readonly TcpClient _client;
	private readonly ILogger _logger;
	private readonly IPacketRegistry _packetRegistry;
	private readonly ICryptoService _cryptoService;
	private readonly ServerConfig _config;

	// Networking
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly MinecraftStream _readStream;
	private readonly MinecraftStream _writeStream;

	// States
	private bool _isConnected;
	private ConnectionState _connectionState;
	private readonly BlockingCollection<IPacket> _packetWriteQueue;
	private byte[]? _verifyToken;

	private bool _isEncrypted;
	private bool _isCompressed;

	public ClientConnection(
		TcpClient client,
		IServer server,
		ILogger logger,
		IPacketRegistry packetRegistry,
		ICryptoService cryptoService,
		ServerConfig config) {

		_client = client;
		_server = server;
		_logger = logger;
		_packetRegistry = packetRegistry;
		_cryptoService = cryptoService;
		_config = config;

		Endpoint = client.Client.RemoteEndPoint!;

		_cancellationTokenSource = new CancellationTokenSource();

		var baseStream = _client.GetStream();
		_readStream = new MinecraftStream(baseStream);
		_writeStream = new MinecraftStream(baseStream);

		_isConnected = true;
		_connectionState = ConnectionState.Handshaking;
		_packetWriteQueue = new BlockingCollection<IPacket>();
	}

	public void Init() {
		Task.Run(SendTask, _cancellationTokenSource.Token).ConfigureAwait(false);
		Task.Run(ReceiveTask, _cancellationTokenSource.Token).ConfigureAwait(false);
	}

	public void Disconnect() {
		if (_cancellationTokenSource.IsCancellationRequested || !_isConnected) {
			return;
		}

		_cancellationTokenSource.Cancel();

		_client.Client.Shutdown(SocketShutdown.Both);
		_client.Close();

		OnDisconnect?.Invoke();
		_isConnected = false;
	}

	#region Send Handler
	private void SendTask() {
		// Temporary stream
		using var ms = new MemoryStream();
		using var mc = new MinecraftStream(ms);

		while (!_cancellationTokenSource.IsCancellationRequested) {
			try {
				var packet = _packetWriteQueue.Take(_cancellationTokenSource.Token);

				// Serialize packet to byte[]
				mc.WriteVarInt(packet.PacketId);
				packet.Serialize(mc);
				var data = ms.ToArray();

				// Write to actual stream
				_writeStream.WriteVarInt(data.Length);
				_writeStream.Write(data);

				// Reset stream
				mc.Position = 0;
				mc.SetLength(0);
			}
			catch (OperationCanceledException) {
				break;
			}
		}
	}

	public void SendPacket(IPacket packet) {
		_logger.Information("[SEND] >> {@Packet}", packet);
		_packetWriteQueue.Add(packet);
	}
	  #endregion

	#region Receive handler
	private void ReceiveTask() {
		try {
			while (!_cancellationTokenSource.IsCancellationRequested) {
				var packetLength = _readStream.ReadVarInt();
				var packetId = (byte)_readStream.ReadVarInt();

				var packet = _packetRegistry.Create(_readStream, _connectionState, packetId);
				HandlePacket(packet);
			}
		}
		catch (Exception ex) {
			if (ex is OperationCanceledException or EndOfStreamException) {
				return;
			}

			_logger.Error(ex, "An unhandled exception occurred in receive task from client: {EndPoint}", _client.Client.RemoteEndPoint!.ToString());
		}
		finally {
			Disconnect();
		}
	}

	private void HandlePacket(IPacket packet) {
		_logger.Information("[RECV] << {@Packet}", packet);

		switch (_connectionState) {
			case ConnectionState.Handshaking:
				HandleHandshake(packet);
				break;
			case ConnectionState.Status:
				HandleStatus(packet);
				break;
			case ConnectionState.Login:
				HandleLogin(packet);
				break;
			case ConnectionState.Play:
				HandlePlay(packet);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void HandleHandshake(IPacket packet) {
		if (packet is HandshakingServerSetProtocol handshake) {
			_connectionState = (ConnectionState)handshake.NextState;
		}
	}

	private void HandleStatus(IPacket packet) {
		switch (packet) {
			case StatusServerPingStart:
				SendPacket(new StatusClientServerInfo(_server.GetMotd()));
				break;
			case StatusServerPing:
				SendPacket(packet);
				Disconnect();
				break;
		}
	}

	private void HandleLogin(IPacket packet) {
		switch (packet) {
			case LoginServerLoginStart loginStart:
				HandleLoginStart(loginStart);
				break;
			case LoginServerEncryptionBegin encryptionBegin:
				HandleEncryptionBegin(encryptionBegin);
				break;
		}
	}

	private void HandleLoginStart(LoginServerLoginStart packet) {
		_logger.Information("User {Username} is trying to login", packet.Username);

		// Get RSA public key from crypto service
		var publicKey = _cryptoService.GetRsaPublicKey();

		// Generate 16-bytes random
		_verifyToken = RandomNumberGenerator.GetBytes(16);

		SendPacket(new LoginClientEncryptionBegin("", publicKey, _verifyToken));
	}

	private void HandleEncryptionBegin(LoginServerEncryptionBegin packet) {
		var decryptedVerifyToken = _cryptoService.DecryptRsa(packet.VerifyToken);
		var decryptedSharedSecret = _cryptoService.DecryptRsa(packet.SharedSecret);

		if (_verifyToken == null) {
			_logger.Error("Verify token is not generated for user");
			Disconnect();
			return;
		}

		if (!decryptedVerifyToken.SequenceEqual(_verifyToken)) {
			_logger.Error("Verify token mismatch: {Expected} != {Actual}", _verifyToken, decryptedVerifyToken);
			Disconnect();
			return;
		}

		_isEncrypted = true;
		_readStream.InitEncryption(decryptedSharedSecret);
		_writeStream.InitEncryption(decryptedSharedSecret);

		ChangeToPlay();
	}

	private void ChangeToPlay() {
		_connectionState = ConnectionState.Play;
		_isCompressed = true;

		SendPacket(new LoginClientCompress(_config.Network.Compression));
		SendPacket(new LoginClientSuccess(Guid.NewGuid(), "Test"));
	}

	private void HandlePlay(IPacket packet) {
		throw new NotImplementedException();
	}
	  #endregion
}
