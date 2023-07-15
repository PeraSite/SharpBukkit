using System.Net;

namespace SharpBukkit.Network.API;

public interface IClientConnection {
	EndPoint Endpoint { get; }
	event Action OnDisconnect;

	void Init();
	void Disconnect();
}
