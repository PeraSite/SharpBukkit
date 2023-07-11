using System;
using Serilog;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.Network.API;
using SharpBukkit.Network.Packets;

namespace SharpBukkit.Core;

public class MinecraftServer : IServer {
	private readonly ServerConfig _config;
	private readonly INetServer _netServer;
	private readonly ILogger _logger;

	public MinecraftServer(ServerConfig config, INetServer netServer, ILogger logger) {
		_config = config;
		_netServer = netServer;
		_logger = logger;
	}

	public void Start() {
		_logger.Information($"{_config}");

		_logger.Information("Loading packets...");
		PacketFactory.Load();

		_logger.Information("Starting server...");
		_netServer.Start();

		while (true) {
			var command = Console.ReadLine();

			// TODO: Command handling system
			if (command == "stop") {
				Stop();
				break;
			}
		}
	}

	public void Stop() {
		_logger.Information("Stopping server...");
		_netServer.Stop();
	}
}
