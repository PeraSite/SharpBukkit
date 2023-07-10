namespace SharpBukkit.Core.Config;

public enum ProtocolType {
	Tcp
}

public record NetworkConfig(
	ProtocolType Protocol,
	string Host,
	int Port
);
