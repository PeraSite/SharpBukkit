using SharpBukkit.Core;

namespace SharpBukkit.Server;

public class Program {
	public static void Main(string[] args) {
		const string configPath = "config.toml";

		MinecraftServer server = new MinecraftServer(configPath);
		server.Start();
	}
}
