using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
	private readonly ILogger<MinecraftServer> _logger;

	public MinecraftServer(
		ServerConfig config,
		INetServer netServer,
		IPacketRegistry packetRegistry,
		ILogger<MinecraftServer> logger
	) {
		_config = config;
		_netServer = netServer;
		_packetRegistry = packetRegistry;
		_logger = logger;
	}

	public async Task Start() {
		_logger.LogInformation("Game Config : \n{@Config}", _config.Game);
		_logger.LogInformation("Network Config : \n{@Config}", _config.Network);

		_logger.LogInformation("Loading packets...");
		_packetRegistry.Load();

		_logger.LogInformation("Starting server...");
		try {
			await _netServer.Start();
		}
		finally {
			await Stop();
		}

		// var running = true;
		// while (running) {
		// 	var command = Console.ReadLine()!;
		//
		// 	switch (command) {
		// 		case "stop":
		// 			await Stop();
		// 			running = false;
		// 			break;
		// 		case "list":
		// 			_logger.LogInformation("Clients: {Count}", _netServer.Connections.Count);
		// 			_logger.LogInformation("Players: [{Players}]",
		// 				string.Join(", ", _netServer.Connections.Values.Select(c => c.Player.Name)));
		// 			break;
		// 	}
		// }
	}

	public async Task Stop() {
		_logger.LogInformation("Stopping server...");
		await _netServer.Stop();
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
