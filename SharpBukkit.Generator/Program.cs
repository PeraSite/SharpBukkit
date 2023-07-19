using System;
using System.Threading.Tasks;
using Serilog;
using SharpBukkit.Generator.Protocol;
using SharpBukkit.Generator.Utils;

async Task GenerateProtocol() {
	const string outputFolder = "../../../../SharpBukkit/Net/Packets";

	var protocolJson = await PrismarineUtils.Read("protocol.json");
	await ProtocolGenerator.Generate(outputFolder, protocolJson);
}

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();

try {
	await GenerateProtocol();
}
catch (Exception e) {
	Console.WriteLine(e);
	throw;
}
