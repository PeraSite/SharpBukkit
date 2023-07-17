﻿using System;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
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
	public static async Task Main() {
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.CreateLogger();

		var host = Host.CreateDefaultBuilder()
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureServices(services => services.AddHostedService<HostService>())
			.ConfigureContainer<ContainerBuilder>(RegisterCore)
			.UseSerilog()
			.Build();

		await host.RunAsync();
	}

	private static void RegisterCore(ContainerBuilder builder) {
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
