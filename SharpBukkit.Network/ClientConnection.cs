using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Serilog;
using SharpBukkit.API;
using SharpBukkit.Network.API;
using SharpBukkit.Network.Models;
using SharpBukkit.Network.Packets;
using SharpBukkit.Packet.Handshaking;
using SharpBukkit.Packet.Status;

namespace SharpBukkit.Network;

public class ClientConnection : IClientConnection {
	public EndPoint Endpoint { get; }
	public event Action? OnDisconnect;

	// Injected
	private readonly IServer _server;
	private readonly TcpClient _client;
	private readonly ILogger _logger;

	// Networking
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly NetworkStream _stream;

	// States
	private bool _isConnected;
	private ConnectionState _connectionState;
	private BlockingCollection<byte[]> _packetWriteQueue { get; }

	public ClientConnection(TcpClient client, IServer server, ILogger logger) {
		_client = client;
		_server = server;
		_logger = logger;

		Endpoint = client.Client.RemoteEndPoint!;

		_cancellationTokenSource = new CancellationTokenSource();
		_stream = _client.GetStream();

		_isConnected = true;
		_connectionState = ConnectionState.Handshaking;
		_packetWriteQueue = new BlockingCollection<byte[]>();
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
		using var ms = new MinecraftStream(_stream);

		while (!_cancellationTokenSource.IsCancellationRequested) {
			try {
				var data = _packetWriteQueue.Take(_cancellationTokenSource.Token);
				ms.WriteVarInt(data.Length);
				ms.Write(data);
			}
			catch (OperationCanceledException) {
				break;
			}
		}
	}

	public void SendPacket(IPacket packet) {
		_logger.Information("[SEND] >> {@Packet}", packet);

		byte[] encodedPacket;
		using (var memoryStream = new MemoryStream()) {
			using (var mc = new MinecraftStream(memoryStream)) {
				mc.WriteVarInt(packet.PacketId);
				packet.Serialize(mc);

				encodedPacket = memoryStream.ToArray();
				mc.Position = 0;
				mc.SetLength(0);
			}
		}
		_packetWriteQueue.Add(encodedPacket);
	}
	  #endregion

	#region Receive handler
	private void ReceiveTask() {
		try {
			using var ms = new MinecraftStream(_stream);

			while (!_cancellationTokenSource.IsCancellationRequested) {
				var packetLength = ms.ReadVarInt();
				var packetId = (byte)ms.ReadVarInt();

				var packet = PacketFactory.Create(ms, _connectionState, packetId);
				HandlePacket(packet);
			}
		}
		catch (Exception ex) {
			if (ex is OperationCanceledException or EndOfStreamException or IOException) {
				_logger.Debug(ex, "Client disconnected: {@Endpoint}", _client.Client.RemoteEndPoint);
				return;
			}

			_logger.Error(ex, "An unhandled exception occurred in receive task: {@EndPoint}", _client.Client.RemoteEndPoint);
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
		if (packet is StatusServerPingStart) {
			SendPacket(new StatusClientServerInfo(_server.GetMotd()));
		} else if (packet is StatusServerPing) {
			SendPacket(packet);
			Disconnect();
		}
	}
	  #endregion
}
