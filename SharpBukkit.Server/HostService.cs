using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using SharpBukkit.API;

namespace SharpBukkit.Server;

public class HostService : BackgroundService {
	private readonly IServer _server;

	public HostService(IServer server) {
		_server = server;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken) {
		_server.Start();
		return Task.CompletedTask;
	}
}
