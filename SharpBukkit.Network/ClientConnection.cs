using System.Net;
using System.Net.Sockets;
using Serilog;
using SharpBukkit.Network.API;

namespace SharpBukkit.Network;

public class ClientConnection : IClientConnection {
	public EndPoint Endpoint { get; }
	public event Action? OnDisconnect;

	private readonly TcpClient _client;
	private readonly ILogger _logger;

	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly NetworkStream _stream;

	public ClientConnection(TcpClient client, ILogger logger) {
		_cancellationTokenSource = new CancellationTokenSource();

		_client = client;
		_logger = logger;

		Endpoint = client.Client.RemoteEndPoint!;
		_stream = _client.GetStream();
	}

	public void Init() {
		Task.Run(SendTask, _cancellationTokenSource.Token);
		Task.Run(ReceiveTask, _cancellationTokenSource.Token);
	}

	public void Disconnect() {
		OnDisconnect?.Invoke();
	}

	private void SendTask() { }

	private void ReceiveTask() {
		var writer = new BinaryWriter(_stream);
		var reader = new BinaryReader(_stream);

		while (!_cancellationTokenSource.IsCancellationRequested) {
			var nickname = reader.ReadString();
			var msg = $"Hello, {nickname}!";
			writer.Write(msg);

			_logger.Information($"Received: {nickname} => {msg}");
		}
	}
}
