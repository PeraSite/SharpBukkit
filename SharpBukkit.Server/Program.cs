using System.IO;
using Autofac;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.Core;
using SharpBukkit.Network;
using SharpBukkit.Network.API;
using Tomlyn;

namespace SharpBukkit.Server;

public static class Program {
	public static void Main() {
		var container = BuildContainer();
		using ILifetimeScope scope = container.BeginLifetimeScope();
		scope.Resolve<MinecraftServer>().Start();
	}

	private static IContainer BuildContainer() {
		var builder = new ContainerBuilder();

		ServerConfig config = ReadConfig();
		builder.RegisterInstance(config)
			.SingleInstance();

		builder.RegisterType<MinecraftServer>()
			.AsSelf()
			.As<IServer>()
			.SingleInstance();

		builder.RegisterType<NetServer>()
			.As<INetServer>()
			.SingleInstance();

		return builder.Build();
	}

	private static ServerConfig ReadConfig() {
		const string configPath = "config.toml";
		var text = File.ReadAllText(configPath);
		return Toml.ToModel<ServerConfig>(text);
	}
}
