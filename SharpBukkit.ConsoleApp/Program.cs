﻿using System.IO;
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
using SharpBukkit.Entity;
using SharpBukkit.Net;
using SharpBukkit.Net.Crypto;
using SharpBukkit.Net.Packets;
using Tomlyn;

namespace SharpBukkit.ConsoleApp;

public static class Program {
	public static async Task Main() {
		var host = Host.CreateDefaultBuilder()
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureServices(services => services.AddHostedService<ServerHostService>())
			.ConfigureContainer<ContainerBuilder>(RegisterCore)
			.UseSerilog((_, configuration) => {
				configuration.MinimumLevel.Debug()
					.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
					.Enrich.FromLogContext()
					.Enrich.With<RemoveTypeTagEnricher>()
					.WriteTo.Console();
			})
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
			.SingleInstance();

		builder.RegisterType<ClientConnection>()
			.InstancePerDependency();

		builder.RegisterType<PacketRegistry>()
			.SingleInstance();

		builder.RegisterType<CryptoService>()
			.InstancePerDependency();

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
