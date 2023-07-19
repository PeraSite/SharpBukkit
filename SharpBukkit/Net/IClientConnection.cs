using System;
using System.Net;
using System.Net.Sockets;
using SharpBukkit.API.Entity;

namespace SharpBukkit.Net;

public interface IClientConnection {
	public delegate IClientConnection Factory(TcpClient client);

	EndPoint Endpoint { get; }
	IPlayer Player { get; set; }

	event Action OnDisconnect;

	void Init();
	void Disconnect();
}