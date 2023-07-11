using System.Net;
using System.Net.Sockets;
using Serilog;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;

namespace SharpBukkit.Network;

public class NetServer : INetServer {
	private readonly ServerConfig _config;
	private readonly ILogger _logger;

	public Dictionary<EndPoint, IClientConnection> Connections { get; }

	private bool _running;
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly TcpListener _tcpListener;

	public NetServer(ServerConfig config, ILogger logger) {
		// Dependencies
		_config = config;
		_logger = logger;

		// States
		_running = true;
		_cancellationTokenSource = new CancellationTokenSource();
		Connections = new Dictionary<EndPoint, IClientConnection>();
		var ipEndpoint = new IPEndPoint(IPAddress.Parse(_config.Network.Host), _config.Network.Port);
		_tcpListener = new TcpListener(ipEndpoint);
	}

	public void Start() {
		_logger.Information("Listening on {Host}:{Port}", _config.Network.Host, _config.Network.Port);
		_tcpListener.Start(_config.Network.Backlog);

		Task.Run(() => {
			while (!_cancellationTokenSource.IsCancellationRequested) {
				var client = _tcpListener.AcceptTcpClient();

				var connection = new ClientConnection(client, _logger);
				connection.OnDisconnect += () => OnClientDisconnected(connection);
				OnClientConnected(connection);

				connection.Init();
			}
		}, _cancellationTokenSource.Token);
	}

	public void Stop() {
		_running = false;
		_cancellationTokenSource.Cancel();
		_tcpListener.Stop();
	}

	public void OnClientConnected(IClientConnection connection) {
		_logger.Information("Client connected: {@Endpoint}", connection.Endpoint);
		Connections[connection.Endpoint] = connection;
	}

	public void OnClientDisconnected(IClientConnection connection) {
		_logger.Information("Client disconnected: {@Endpoint}", connection.Endpoint);
		Connections.Remove(connection.Endpoint);
	}
}
