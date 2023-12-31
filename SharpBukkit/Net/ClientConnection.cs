using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.API.Entity;
using SharpBukkit.Entity;
using SharpBukkit.Net.Crypto;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Packets;
using SharpBukkit.Net.Utils;

namespace SharpBukkit.Net;

public class ClientConnection {
	public delegate ClientConnection Factory(TcpClient client);

	public EndPoint Endpoint { get; }
	public IPlayer? Player { get; set; }

	public event Action? OnDisconnect;

	// Injected
	private readonly IServer _server;
	private readonly ILogger<ClientConnection> _logger;
	private readonly PacketRegistry _packetRegistry;
	private readonly CryptoService _cryptoService;
	private readonly ServerConfig _config;
	private readonly Player.Factory _playerFactory;

	// Networking
	private readonly TcpClient _client;
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly MinecraftStream _readStream;
	private readonly MinecraftStream _writeStream;

	// States
	private ConnectionState _connectionState;
	private readonly BlockingCollection<(byte[], Action?)> _packetWriteQueue;
	private byte[]? _verifyToken;

	private bool _isCompressed;

	public ClientConnection(
		IHostApplicationLifetime lifetime,
		TcpClient client,
		IServer server,
		ILogger<ClientConnection> logger,
		PacketRegistry packetRegistry,
		CryptoService cryptoService,
		ServerConfig config,
		Player.Factory playerFactory) {
		// Actual parameter
		_client = client;

		// Injected
		_server = server;
		_logger = logger;
		_packetRegistry = packetRegistry;
		_cryptoService = cryptoService;
		_config = config;
		_playerFactory = playerFactory;

		// Initialization logic
		Endpoint = client.Client.RemoteEndPoint!;

		_cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(lifetime.ApplicationStopping);

		var baseStream = _client.GetStream();
		_readStream = new MinecraftStream(baseStream);
		_writeStream = new MinecraftStream(baseStream);

		_connectionState = ConnectionState.Handshaking;
		_packetWriteQueue = new BlockingCollection<(byte[], Action?)>();
	}

	public void Init() {
		Task.Run(SendTask, _cancellationTokenSource.Token).ConfigureAwait(false);
		Task.Run(ReceiveTask, _cancellationTokenSource.Token).ConfigureAwait(false);
	}

	public void Disconnect() {
		if (!_client.Connected) {
			return;
		}

		_cancellationTokenSource.Cancel();

		_client.Client.Shutdown(SocketShutdown.Both);
		_client.Close();

		OnDisconnect?.Invoke();
	}

	#region Send Handler
	private void SendTask() {
		while (!_cancellationTokenSource.IsCancellationRequested) {
			try {
				var (packetData, onComplete) = _packetWriteQueue.Take(_cancellationTokenSource.Token);

				_writeStream.WriteVarInt(packetData.Length);
				_writeStream.Write(packetData);

				// Invoke callback function
				onComplete?.Invoke();
			}
			catch (OperationCanceledException) {
				break;
			}
		}
	}

	private void SendPacket(IPacket packet, Action? onSendComplete = null) {
		_logger.LogDebug("[SEND] >> {Name} {@Packet}", packet.GetType().Name, packet);

		byte[] encodedPacket;

		using (var ms = new MemoryStream()) {
			using var mc = new MinecraftStream(ms);
			// Write packet id, data
			mc.WriteVarInt(packet.PacketId);
			packet.Serialize(mc);

			// Get uncompressed packet data
			encodedPacket = ms.ToArray();

			// Reset stream
			mc.Position = 0;
			mc.SetLength(0);

			if (_isCompressed) {
				if (encodedPacket.Length >= _config.Network.CompressionThreshold) {
					var compressed = CompressUtil.CompressData(encodedPacket);
					mc.WriteVarInt(encodedPacket.Length);
					mc.Write(compressed);
				} else {
					// Uncompressed
					mc.WriteVarInt(0);
					mc.Write(encodedPacket);
				}
				encodedPacket = ms.ToArray();
			}
		}

		_packetWriteQueue.Add((encodedPacket, onSendComplete));
	}
	  #endregion

	#region Receive handler
	private async Task ReceiveTask() {
		try {
			while (!_cancellationTokenSource.IsCancellationRequested) {
				byte packetId;
				byte[] packetData;

				if (_isCompressed) {
					var length = _readStream.ReadVarInt();
					var dataLength = _readStream.ReadVarInt(out var dataLengthLength);

					// Data is not compressed if data length is 0
					if (dataLength == 0) {
						packetId = (byte)_readStream.ReadVarInt(out var idLength);
						packetData = _readStream.Read(length - (dataLengthLength + idLength));
					} else {
						// Data is compressed
						var data = _readStream.Read(length - dataLengthLength);
						var decompressed = CompressUtil.DecompressData(data);
						using var ms = new MemoryStream(decompressed);
						await using var mc = new MinecraftStream(ms);

						packetId = (byte)mc.ReadVarInt(out var l);
						packetData = mc.Read(dataLength - l);
					}
				} else {
					var length = _readStream.ReadVarInt();
					packetId = (byte)_readStream.ReadVarInt(out var idLength);
					packetData = _readStream.Read(length - idLength);
				}

				var dataStream = new MinecraftStream(new MemoryStream(packetData));
				var packet = _packetRegistry.Create(dataStream, _connectionState, packetId);
				await HandlePacket(packet);
			}
		}
		catch (Exception ex) {
			if (ex is OperationCanceledException or EndOfStreamException) {
				return;
			}

			_logger.LogError(ex, "An unhandled exception occurred in receive task from client: {EndPoint}", _client.Client.RemoteEndPoint!.ToString());
		}
		finally {
			Disconnect();
		}
	}

	private async Task HandlePacket(IPacket packet) {
		_logger.LogDebug("[RECV] << {Name} {@Packet}", packet.GetType().Name, packet);

		switch (_connectionState) {
			case ConnectionState.Handshaking:
				await HandleHandshake(packet);
				break;
			case ConnectionState.Status:
				await HandleStatus(packet);
				break;
			case ConnectionState.Login:
				await HandleLogin(packet);
				break;
			case ConnectionState.Play:
				await HandlePlay(packet);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private Task HandleHandshake(IPacket packet) {
		if (packet is HandshakingServerSetProtocol handshake) {
			_connectionState = (ConnectionState)handshake.NextState;
		}
		return Task.CompletedTask;
	}

	private Task HandleStatus(IPacket packet) {
		switch (packet) {
			case StatusServerPingStart:
				SendPacket(new StatusClientServerInfo(_server.GetMotd()));
				break;
			case StatusServerPing:
				SendPacket(packet);
				Disconnect();
				break;
		}
		return Task.CompletedTask;
	}

	private async Task HandleLogin(IPacket packet) {
		switch (packet) {
			case LoginServerLoginStart loginStart:
				HandleLoginStart(loginStart);
				break;
			case LoginServerEncryptionBegin encryptionBegin:
				await HandleEncryptionBegin(encryptionBegin);
				break;
		}
	}

	private void HandleLoginStart(LoginServerLoginStart packet) {
		_logger.LogInformation("User {Username} is trying to login", packet.Username);

		Player = _playerFactory(Guid.NewGuid(), packet.Username);

		// If it's offline mode, just login
		if (!_config.Game.OnlineMode) {
			ChangeToPlay();
			return;
		}

		// Get RSA public key from crypto service
		var publicKey = _cryptoService.GetRsaPublicKey();

		// Generate 16-bytes random
		_verifyToken = RandomNumberGenerator.GetBytes(16);

		SendPacket(new LoginClientEncryptionBegin("", publicKey, _verifyToken));
	}

	private async Task HandleEncryptionBegin(LoginServerEncryptionBegin packet) {
		var decryptedVerifyToken = _cryptoService.DecryptRsa(packet.VerifyToken);
		var decryptedSharedSecret = _cryptoService.DecryptRsa(packet.SharedSecret);

		if (_verifyToken == null) {
			_logger.LogError("Verify token is not generated for user");
			Disconnect();
			return;
		}

		if (!decryptedVerifyToken.SequenceEqual(_verifyToken)) {
			_logger.LogError("Verify token mismatch: {Expected} != {Actual}", _verifyToken, decryptedVerifyToken);
			Disconnect();
			return;
		}

		_readStream.InitEncryption(decryptedSharedSecret);
		_writeStream.InitEncryption(decryptedSharedSecret);

		try {
			var result = await AuthMojang(decryptedSharedSecret);

			if (!result || Player is null) {
				_logger.LogError("Failed to authenticate user");
				Disconnect();
				return;
			}

			_logger.LogInformation("User {Username} logged in", Player.Name);

			ChangeToPlay();
		}
		catch (Exception e) {
			_logger.LogError(e, "Failed to authenticate user");
			throw;
		}
	}

	private async Task<bool> AuthMojang(byte[] sharedSecret) {
		if (Player is null) throw new InvalidOperationException("Player is null");

		string serverHash;
		using (var ms = new MemoryStream()) {
			var ascii = Encoding.ASCII.GetBytes("");
			ms.Write(ascii, 0, ascii.Length);
			ms.Write(sharedSecret, 0, 16);
			ms.Write(_cryptoService.GetRsaPublicKey(), 0, _cryptoService.GetRsaPublicKey().Length);
			serverHash = MinecraftShaDigest(ms.ToArray());
		}

		using var httpClient = new HttpClient();

		var url = $"https://sessionserver.mojang.com/session/minecraft/hasJoined?username={Player.Name}&serverId={serverHash}";

		var res = await httpClient.GetAsync(url, _cancellationTokenSource.Token);
		var text = await res.Content.ReadAsStringAsync(_cancellationTokenSource.Token);

		var auth = JsonConvert.DeserializeObject<AuthResponse>(text);

		// Can't parse to auth object
		if (auth == null) {
			return false;
		}

		Player.Name = auth.Name;
		Player.DisplayName = auth.Name;
		Player.Id = new Guid(auth.Id);
		Player.SkinProperties = auth.Properties;

		return true;
	}

	private void ChangeToPlay() {
		if (Player is null) throw new InvalidOperationException("Player is null");

		_connectionState = ConnectionState.Play;

		var threshold = _config.Network.CompressionThreshold;
		if (threshold > 0) {
			SendPacket(new LoginClientCompress(threshold));
			_isCompressed = true;
		}
		SendPacket(new LoginClientSuccess(Player.Id, Player.Name));

		// TODO: Do this in player class
		// SendPacket(new PlayClientLogin(
		// 	167,
		// 	false,
		// 	1, // Creative,
		// 	-1,
		// 	new[] {"minecraft:overworld", "minecraft:the_nether", "minecraft:the_end"},
		// 	new DimensionCodec {
		// 		Realms = Defaults.Realms,
		// 		Biomes = Defaults.Biomes,
		// 	},
		// 	Defaults.CurrentDim,
		// 	Defaults.WorldName,
		// 	-660566458,
		// 	20,
		// 	10,
		// 	10,
		// 	false,
		// 	true,
		// 	false,
		// 	false
		// ));
		// SendPacket(new PlayClientDifficulty(1, false));
		// SendPacket(new PlayClientAbilities(0, 0.05000000074505806f, 0.10000000149011612f));
		// SendPacket(new PlayClientHeldItemSlot(0));
		// SendPacket(new PlayClientCustomPayload("minecraft:brand", new byte[] {7, 118, 97, 110, 105, 108, 108, 97}));
	}

	private Task HandlePlay(IPacket packet) {
		throw new NotImplementedException();
	}
	  #endregion

	// Reference: https://git.io/fhjp6
	private static string MinecraftShaDigest(byte[] input) {
		var hash = SHA1.HashData(input);
		// Reverse the bytes since BigInteger uses little endian
		Array.Reverse(hash);

		BigInteger b = new BigInteger(hash);
		// very annoyingly, BigInteger in C# tries to be smart and puts in
		// a leading 0 when formatting as a hex number to allow roundtripping
		// of negative numbers, thus we have to trim it off.
		if (b < 0) {
			// toss in a negative sign if the interpreted number is negative
			return "-" + (-b).ToString("x").TrimStart('0');
		} else {
			return b.ToString("x").TrimStart('0');
		}
	}
}
