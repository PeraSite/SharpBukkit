using System.Net;
using SharpBukkit.API;

namespace SharpBukkit.Network.API;

public interface INetServer : IServer {

	Dictionary<EndPoint, IClientConnection> Connections { get; }

	void OnClientConnected(IClientConnection connection);

	void OnClientDisconnected(IClientConnection connection);
}
