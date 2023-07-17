using Newtonsoft.Json;

namespace SharpBukkit.API.Auth;

public record SkinProperty {
	[JsonProperty("name")]
	public string Name;

	[JsonProperty("value")]
	public string Value;

	[JsonProperty("signature")]
	public string Signature;
};
