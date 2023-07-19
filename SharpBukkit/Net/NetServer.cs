using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharpBukkit.API.Config;

namespace SharpBukkit.Net;

public class NetServer {
	// Injected
	private readonly ServerConfig _config;
	private readonly ILogger<NetServer> _logger;
	private readonly ClientConnection.Factory _connectionFactory;

	// States
	public Dictionary<EndPoint, ClientConnection> Connections { get; }
	private readonly CancellationTokenSource _cancellationTokenSource;
	private readonly TcpListener _tcpListener;

	public NetServer(
		IHostApplicationLifetime lifetime,
		ServerConfig config,
		ILogger<NetServer> logger,
		ClientConnection.Factory connectionFactory
	) {
		// Dependencies
		_config = config;
		_logger = logger;
		_connectionFactory = connectionFactory;

		// States
		_cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(lifetime.ApplicationStopping);
		Connections = new Dictionary<EndPoint, ClientConnection>();
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

	private void OnClientConnected(ClientConnection connection) {
		_logger.LogInformation("Client connected: {Endpoint}", connection.Endpoint.ToString());
		Connections[connection.Endpoint] = connection;
	}

	private void OnClientDisconnected(ClientConnection connection) {
		_logger.LogInformation("Client disconnected: {Endpoint}", connection.Endpoint.ToString());
		Connections.Remove(connection.Endpoint);
	}
}
