using SharpBukkit.API;

namespace SharpBukkit.Network.API;

public interface INetServer : IServer {
	void OnClientConnected(IClientConnection connection);

	void OnClientDisconnected(IClientConnection connection);
}
