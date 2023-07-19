using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.API.Meta;
using SharpBukkit.Net;
using SharpBukkit.Net.Packets;
using SharpBukkit.Utils;

namespace SharpBukkit;

public class MinecraftServer : IServer {
	#region Constants
	private const int PROTOCOL_ID = 758;
	private const string PROTOCOL_NAME = "1.18.2";
#endregion

	private readonly ServerConfig _config;
	private readonly NetServer _netServer;
	private readonly PacketRegistry _packetRegistry;
	private readonly ILogger<MinecraftServer> _logger;
	private readonly IHostApplicationLifetime _lifetime;

	public MinecraftServer(
		ServerConfig config,
		NetServer netServer,
		PacketRegistry packetRegistry,
		ILogger<MinecraftServer> logger,
		IHostApplicationLifetime lifetime) {
		_config = config;
		_netServer = netServer;
		_packetRegistry = packetRegistry;
		_logger = logger;
		_lifetime = lifetime;
	}

	public async Task Start() {
		_logger.LogInformation("Game Config : \n{@Config}", _config.Game);
		_logger.LogInformation("Network Config : \n{@Config}", _config.Network);

		_logger.LogInformation("Loading packets...");
		_packetRegistry.Load();

		_logger.LogInformation("Starting server...");
		try {
			await Task.WhenAll(
				_netServer.Start(),
				HandleCommand()
			);
		}
		catch (Exception e) {
			_logger.LogError(e, "Server crashed");
		}
		finally {
			await Stop();
		}
	}

	private Task HandleCommand() {
		var running = true;
		while (running) {
			var command = Console.ReadLine()!;

			switch (command) {
				case "stop":
					_lifetime.StopApplication();
					running = false;
					break;
				case "list":
					_logger.LogInformation("Clients: {Count}", _netServer.Connections.Count);
					_logger.LogInformation("Players: [{Players}]",
						string.Join(", ", _netServer.Connections.Values.Select(c => c.Player?.Name)));
					break;
			}
		}
		return Task.CompletedTask;
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
