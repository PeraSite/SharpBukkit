using System;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;
using SharpBukkit.Network.Packets;

namespace SharpBukkit.Core;

public class MinecraftServer : IServer {
	private readonly ServerConfig _config;
	private readonly INetServer _netServer;

	public MinecraftServer(ServerConfig config, INetServer netServer) {
		_config = config;
		_netServer = netServer;
	}

	public void Start() {
		Console.WriteLine($"Config: {_config}");

		Console.WriteLine("Loading packets...");
		PacketFactory.Load();

		Console.WriteLine("Starting server...");
		_netServer.Start();
	}

	public void Stop() { }
}
