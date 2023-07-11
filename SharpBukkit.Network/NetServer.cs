using System.Net;
using System.Net.Sockets;
using Serilog;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;

namespace SharpBukkit.Network;

public class NetServer : INetServer {
	private readonly ServerConfig _config;
	private readonly ILogger _logger;

	private readonly Dictionary<EndPoint, IClientConnection> _connections;
	private readonly TcpListener _tcpListener;

	public NetServer(ServerConfig config, ILogger logger) {
		// Dependencies
		_config = config;
		_logger = logger;

		// States
		_connections = new Dictionary<EndPoint, IClientConnection>();
		var ipEndpoint = new IPEndPoint(IPAddress.Parse(_config.Network.Host), _config.Network.Port);
		_tcpListener = new TcpListener(ipEndpoint);
	}

	public void Start() {
		_tcpListener.Start(_config.Network.Backlog);
		_logger.Information($"Server started on {_config.Network.Host}:{_config.Network.Port}");

		while (true) {
			var client = _tcpListener.AcceptTcpClient();

			var connection = new ClientConnection(client);
			connection.OnDisconnect += () => OnClientDisconnected(connection);
			OnClientConnected(connection);
		}
	}

	public void Stop() {
		_logger.Information("Stopping server...");
		_tcpListener.Stop();
	}

	public void OnClientConnected(IClientConnection connection) {
		_logger.Information($"Client connected: {connection.Endpoint}");
		_connections[connection.Endpoint] = connection;
	}

	public void OnClientDisconnected(IClientConnection connection) {
		_logger.Information($"Client disconnected: {connection.Endpoint}");
		_connections.Remove(connection.Endpoint);
	}
}
