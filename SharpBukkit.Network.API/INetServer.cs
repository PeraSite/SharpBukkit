using System.Net;

namespace SharpBukkit.Network.API;

public interface INetServer {
	Dictionary<EndPoint, IClientConnection> Connections { get; }

	void Start();

	void Stop();

	void OnClientConnected(IClientConnection connection);

	void OnClientDisconnected(IClientConnection connection);
}
