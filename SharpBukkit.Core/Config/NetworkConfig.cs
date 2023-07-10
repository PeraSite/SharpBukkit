namespace SharpBukkit.Core.Config;

public enum ProtocolType {
	Tcp
}

public record NetworkConfig {
	public ProtocolType Protocol { get; init; }
	public string Host { get; init; }
	public int Port { get; init; }
}
