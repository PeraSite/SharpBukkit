namespace SharpBukkit.Core.Config;

public record ServerConfig {
	public GameConfig Game { get; init; }
	public NetworkConfig Network { get; init; }
}
