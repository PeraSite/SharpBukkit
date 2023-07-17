﻿using System.IO;
using Autofac;
using Serilog;
using SharpBukkit.API;
using SharpBukkit.API.Config;
using SharpBukkit.API.Entity;
using SharpBukkit.Core;
using SharpBukkit.Core.Entity;
using SharpBukkit.Network;
using SharpBukkit.Network.API;
using SharpBukkit.Network.Crypto;
using SharpBukkit.Network.Packets;
using Tomlyn;

namespace SharpBukkit.Server;

public static class Program {
	public static void Main() {
		var container = BuildContainer();
		using ILifetimeScope scope = container.BeginLifetimeScope();
		scope.Resolve<IServer>().Start();
	}

	private static IContainer BuildContainer() {
		var builder = new ContainerBuilder();

		ServerConfig config = ReadConfig();
		builder.RegisterInstance(config)
			.SingleInstance();

		builder.RegisterType<MinecraftServer>()
			.As<IServer>()
			.SingleInstance();

		builder.RegisterType<NetServer>()
			.As<INetServer>()
			.SingleInstance();

		builder.RegisterType<ClientConnection>()
			.As<IClientConnection>()
			.InstancePerDependency();

		builder.RegisterType<PacketRegistry>()
			.As<IPacketRegistry>()
			.SingleInstance();

		builder.RegisterType<CryptoService>()
			.SingleInstance();

		RegisterEntityTypes(builder);

		var logger = new LoggerConfiguration()
			.Enrich.With(new RemoveTypeTagEnricher())
			.WriteTo.Console()
			.CreateLogger();

		builder.RegisterInstance(logger)
			.As<ILogger>()
			.SingleInstance();

		return builder.Build();
	}

	private static void RegisterEntityTypes(ContainerBuilder builder) {
		// TODO: Register entity type automatically by scanning assembly
		builder.RegisterType<Player>()
			.As<IPlayer>();
	}

	private static ServerConfig ReadConfig() {
		const string configPath = "config.toml";
		var text = File.ReadAllText(configPath);
		return Toml.ToModel<ServerConfig>(text);
	}
}
