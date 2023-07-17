using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharpBukkit.API;

namespace SharpBukkit.ConsoleApp;

public class ServerHostService : BackgroundService {
	private readonly IServer _server;
	private readonly IHostApplicationLifetime _lifetime;
	private readonly ILogger<ServerHostService> _logger;

	public ServerHostService(IServer server, IHostApplicationLifetime lifetime, ILogger<ServerHostService> logger) {
		_server = server;
		_lifetime = lifetime;
		_logger = logger;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		try {
			_logger.LogInformation("Starting server...");
			await _server.Start();
		}
		finally {
			_lifetime.StopApplication();
		}
	}
}
