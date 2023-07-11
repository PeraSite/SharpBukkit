namespace SharpBukkit.API;

public interface IServer {
	void Start();
	void Stop();

	string GetMotd();
}
