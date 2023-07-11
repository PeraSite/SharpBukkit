namespace SharpBukkit.API.Meta;

public record MetaPlayers {
	public int Max { get; set; }
	public int Online { get; set; }
	public List<MetaSample> Sample { get; set; }
}
