namespace SharpBukkit.API;

public interface IServer {
	Task Start();
	Task Stop();

	string GetMotd();
}
