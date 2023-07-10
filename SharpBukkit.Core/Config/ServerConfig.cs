namespace SharpBukkit.Core.Config;

public record ServerConfig(
	string Motd,
	int MaxPlayer,
	bool OnlineMode,
	string Favicon
);
