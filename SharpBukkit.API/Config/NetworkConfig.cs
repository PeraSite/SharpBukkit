namespace SharpBukkit.API.Config;

public record NetworkConfig {
	public string Host { get; private set; }
	public int Port { get; private set; }
	public int Backlog { get; private set; }
	public int Compression { get; private set; }
}
