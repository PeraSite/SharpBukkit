using System.Net;
using System.Net.Sockets;
using Serilog;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;

namespace SharpBukkit.Network;

public class NetServer : INetServer {
	// Injected
	private readonly ServerConfig _config;
	private readonly ILogger _logger;
	private readonly ClientConnection.Factory _connectionFactory;

	// States
	public Dictionary<EndPoint, IClientConnection> Connections { get; }
	private bool _running;
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly TcpListener _tcpListener;

	public NetServer(
		ServerConfig config,
		ILogger logger,
		ClientConnection.Factory connectionFactory
	) {
		// Dependencies
		_config = config;
		_logger = logger;
		_connectionFactory = connectionFactory;

		// States
		_running = true;
		_cancellationTokenSource = new CancellationTokenSource();
		Connections = new Dictionary<EndPoint, IClientConnection>();
		_tcpListener = new TcpListener(IPAddress.Parse(_config.Network.Host), _config.Network.Port);
	}

	public void Start() {
		_logger.Information("Listening on {Host}:{Port}", _config.Network.Host, _config.Network.Port);
		_tcpListener.Start(_config.Network.Backlog);

		Task.Run(() => {
			try {
				while (!_cancellationTokenSource.IsCancellationRequested) {
					var client = _tcpListener.AcceptTcpClient();

					var connection = _connectionFactory(client);
					connection.OnDisconnect += () => OnClientDisconnected(connection);
					OnClientConnected(connection);

					connection.Init();
				}
			}
			catch (Exception e) {
				_logger.Error(e, "Error while listening for connections");
				throw;
			}
		}, _cancellationTokenSource.Token);
	}

	public void Stop() {
		_running = false;
		_cancellationTokenSource.Cancel();
		_tcpListener.Stop();
	}

	public void OnClientConnected(IClientConnection connection) {
		_logger.Information("Client connected: {Endpoint}", connection.Endpoint.ToString());
		Connections[connection.Endpoint] = connection;
	}

	public void OnClientDisconnected(IClientConnection connection) {
		_logger.Information("Client disconnected: {Endpoint}", connection.Endpoint.ToString());
		Connections.Remove(connection.Endpoint);
	}
}
