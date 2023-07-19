using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SharpBukkit.Net;

public interface INetServer {
	Dictionary<EndPoint, IClientConnection> Connections { get; }

	Task Start();

	Task Stop();

	void OnClientConnected(IClientConnection connection);

	void OnClientDisconnected(IClientConnection connection);
}
