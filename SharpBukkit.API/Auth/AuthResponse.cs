using Newtonsoft.Json;

namespace SharpBukkit.API.Auth;

public record AuthResponse {
	[JsonProperty("id")]
	public string Id;

	[JsonProperty("name")]
	public string Name;

	[JsonProperty("properties")]
	public Property[] Properties;

	public record Property {
		[JsonProperty("name")]
		public string Name;

		[JsonProperty("value")]
		public string Value;

		[JsonProperty("signature")]
		public string Signature;
	}
}
