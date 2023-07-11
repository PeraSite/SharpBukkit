using System.Net;
using System.Net.Sockets;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;

namespace SharpBukkit.Network;

public class NetServer : INetServer {
	private readonly ServerConfig _config;

	private TcpListener _tcpListener;

	public NetServer(ServerConfig config) {
		_config = config;

		var ipEndpoint = new IPEndPoint(IPAddress.Parse(_config.Network.Host), _config.Network.Port);
		_tcpListener = new TcpListener(ipEndpoint);
	}

	public void Start() {
		_tcpListener.Start(_config.Network.Backlog);
	}

	public void Stop() {
		_tcpListener.Stop();
	}

	public void OnClientConnected(IClientConnection connection) { }

	public void OnClientDisconnected(IClientConnection connection) { }
}
