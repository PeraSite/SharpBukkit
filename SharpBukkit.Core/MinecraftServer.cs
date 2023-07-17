using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Serilog;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.API.Meta;
using SharpBukkit.Core.Utils;
using SharpBukkit.Network.API;

namespace SharpBukkit.Core;

public class MinecraftServer : IServer {
	#region Constants
	private const int PROTOCOL_ID = 758;
	private const string PROTOCOL_NAME = "1.18.2";
#endregion

	private readonly ServerConfig _config;
	private readonly INetServer _netServer;
	private readonly IPacketRegistry _packetRegistry;
	private readonly ILogger _logger;

	public MinecraftServer(
		ServerConfig config,
		INetServer netServer,
		IPacketRegistry packetRegistry,
		ILogger logger
	) {
		_config = config;
		_netServer = netServer;
		_packetRegistry = packetRegistry;
		_logger = logger;
	}

	public void Start() {
		_logger.Information("Game Config : \n{@Config}", _config.Game);
		_logger.Information("Network Config : \n{@Config}", _config.Network);

		_logger.Information("Loading packets...");
		_packetRegistry.Load();

		_logger.Information("Starting server...");
		_netServer.Start();

		var running = true;
		while (running) {
			var command = Console.ReadLine()!;

			switch (command) {
				case "stop":
					Stop();
					running = false;
					break;
				case "list":
					_logger.Information("Clients: {Count}", _netServer.Connections.Count);
					_logger.Information("Players: [{Players}]",
						string.Join(", ", _netServer.Connections.Values.Select(c => c.Player.Name)));
					break;
			}
		}
	}

	public void Stop() {
		_logger.Information("Stopping server...");
		_netServer.Stop();
	}

	public string GetMotd() {
		var serverInfo = new MetaServer {
			Version = new MetaVersion {
				Name = PROTOCOL_NAME,
				Protocol = PROTOCOL_ID
			},
			Players = new MetaPlayers {
				Max = _config.Game.MaxPlayer,
				Online = _netServer.Connections.Count,
				Sample = new List<MetaSample> {
					new MetaSample {
						Id = Guid.NewGuid().ToString(),
						Name = "john_doe"
					}
				}
			},
			Description = new MetaDescription {
				Text = _config.Game.Motd
			}
		};

		if (_config.Game.Favicon is { } faviconPath) {
			var path = Path.Combine(AppContext.BaseDirectory, faviconPath);
			var favBytes = File.ReadAllBytes(path);
			serverInfo.Favicon = $"data:image/png;base64,{Convert.ToBase64String(favBytes)}";
		}

		return JsonConvert.SerializeObject(serverInfo, JsonHelper.Config);
	}
}
