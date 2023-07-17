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
	private readonly IClientConnection.Factory _connectionFactory;

	// States
	public Dictionary<EndPoint, IClientConnection> Connections { get; }
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly TcpListener _tcpListener;

	public NetServer(
		IHostApplicationLifetime lifetime,
		ServerConfig config,
		ILogger logger,
		IClientConnection.Factory connectionFactory
	) {
		// Dependencies
		_config = config;
		_logger = logger;
		_connectionFactory = connectionFactory;

		// States
		_cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(lifetime.ApplicationStopping);
		Connections = new Dictionary<EndPoint, IClientConnection>();
		_tcpListener = new TcpListener(IPAddress.Parse(_config.Network.Host), _config.Network.Port);
	}

	public async Task Start() {
		_logger.LogInformation("Listening on {Host}:{Port}", _config.Network.Host, _config.Network.Port);
		_tcpListener.Start(_config.Network.Backlog);

		while (!_cancellationTokenSource.IsCancellationRequested) {
			var client = await _tcpListener.AcceptTcpClientAsync(_cancellationTokenSource.Token);

			var connection = _connectionFactory(client);
			connection.OnDisconnect += () => OnClientDisconnected(connection);
			OnClientConnected(connection);

			connection.Init();
		}
	}

	public Task Stop() {
		_tcpListener.Stop();
		return Task.CompletedTask;
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
