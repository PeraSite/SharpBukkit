using Newtonsoft.Json;
using SharpBukkit.API.Auth;

namespace SharpBukkit.Net.Models;

public record AuthResponse {
	[JsonProperty("id")]
	public string Id;

	[JsonProperty("name")]
	public string Name;

	[JsonProperty("properties")]
	public SkinProperty[] Properties;
}
