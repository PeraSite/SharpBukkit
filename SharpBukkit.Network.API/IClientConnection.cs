using System.Net;

namespace SharpBukkit.Network.API;

public interface IClientConnection {
	public EndPoint Endpoint { get; }
	public event Action OnDisconnect;
}
