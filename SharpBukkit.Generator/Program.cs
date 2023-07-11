using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SharpBukkit.Generator.Protocol;
using SharpBukkit.Generator.Utils;

async Task GenerateProtocol() {
	const string outputFolder = "../../../../SharpBukkit.Network/Packets";

	var protocolJson = await PrismarineUtils.Read("protocol.json");
	var fileNameToContent = ProtocolParser.Parse(protocolJson);

	await Task.WhenAll(fileNameToContent.Select(pair => {
		var ((directoryName, fileName), content) = pair;

		Directory.CreateDirectory(Path.Combine(outputFolder, directoryName));
		Console.WriteLine($"Writing {fileName} to {directoryName}");

		var output = Path.Combine(outputFolder, directoryName, fileName);
		return File.WriteAllLinesAsync(output, new[] {content});
	}));
}

await GenerateProtocol();
