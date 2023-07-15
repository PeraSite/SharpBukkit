using System;
using System.Threading.Tasks;
using SharpBukkit.Generator.Protocol;
using SharpBukkit.Generator.Utils;

async Task GenerateProtocol() {
	const string outputFolder = "../../../../SharpBukkit.Network/Packets";

	var protocolJson = await PrismarineUtils.Read("protocol.json");
	await ProtocolGenerator.Generate(outputFolder, protocolJson);
}

try {
	await GenerateProtocol();
}
catch (Exception e) {
	Console.WriteLine(e);
	throw;
}
