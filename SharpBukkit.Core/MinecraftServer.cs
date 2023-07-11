using System;
using System.IO;
using SharpBukkit.Core.Config;
using Tomlyn;

namespace SharpBukkit.Core;

public class MinecraftServer {
	private readonly ServerConfig _config;

	public MinecraftServer(string configPath) {
		_config = ReadConfig(configPath);
	}

	public void Start() {
		Console.WriteLine(_config);
	}

	private ServerConfig ReadConfig(string configPath) {
		var text = File.ReadAllText(configPath);
		return Toml.ToModel<ServerConfig>(text);
	}
}
