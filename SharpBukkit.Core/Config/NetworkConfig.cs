namespace SharpBukkit.Core.Config;

public enum ProtocolType {
	Tcp
}

public record NetworkConfig {
	public ProtocolType Protocol { get; private set; }
	public string Host { get; private set; }
	public int Port { get; private set; }
}
