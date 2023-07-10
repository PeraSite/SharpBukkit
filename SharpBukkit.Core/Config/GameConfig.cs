namespace SharpBukkit.Core.Config;

public record GameConfig {
	public string Motd { get; init; }
	public int MaxPlayer { get; init; }
	public bool OnlineMode { get; init; }
	public string Favicon { get; init; }
}
