namespace SharpBukkit.API.Config;

public record ServerConfig {
	public GameConfig Game { get; private set; }
	public NetworkConfig Network { get; private set; }
}
