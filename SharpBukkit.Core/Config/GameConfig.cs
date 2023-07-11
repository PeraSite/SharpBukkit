namespace SharpBukkit.Core.Config;

public record GameConfig {
	public string Motd { get; private set; }
	public int MaxPlayer { get; private set; }
	public bool OnlineMode { get; private set; }
	public string Favicon { get; private set; }
}
