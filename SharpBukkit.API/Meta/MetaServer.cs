namespace SharpBukkit.API.Meta;

public record MetaServer {
	public MetaVersion Version { get; set; }
	public MetaPlayers Players { get; set; }
	public MetaDescription Description { get; set; }
	public string? Favicon { get; set; }
}
