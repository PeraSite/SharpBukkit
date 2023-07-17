using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharpBukkit.Utils;

internal static class JsonHelper {
	public static readonly JsonSerializerSettings Config = new JsonSerializerSettings {
		ContractResolver = new CamelCasePropertyNamesContractResolver(),
		NullValueHandling = NullValueHandling.Ignore
	};
}
