using System.Net.Http;
using System.Threading.Tasks;

namespace SharpBukkit.Generator.Utils;

public static class PrismarineUtils {
	public static async Task<string> Read(string fileName, string version = GeneratorSetting.MINECRAFT_VERSION) {
		const string repo = "https://raw.githubusercontent.com/PrismarineJS/minecraft-data";
		var url = $"{repo}/master/data/pc/{version}/{fileName}";

		using var client = new HttpClient();
		return await client.GetStringAsync(url);
	}
}
