using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpBukkit.Generator.Protocol.Mapper;

namespace SharpBukkit.Generator.Protocol;

public static class ProtocolParser {
	public static Dictionary<(string folder, string fileName), string> Parse(string protocolJson, bool debug = false) {
		var json = JsonConvert.DeserializeObject<JObject>(protocolJson);
		if (json == null) {
			throw new InvalidOperationException("Empty JSON!");
		}

		var fileNameToContent = new Dictionary<(string, string), string>();

		foreach (PacketType packetType in new[] {PacketType.Handshaking, PacketType.Status, PacketType.Login, PacketType.Play}) {
			var typeName = Enum.GetName(typeof(PacketType), packetType)!;
			var typeNameLower = typeName.ToLower();

			if (!json.TryGetValue(typeNameLower, out var namespaceJson)) {
				throw new Exception($"Can't find packet type: {typeNameLower}");
			}

			var toClientJson = namespaceJson["toClient"]!.ToObject<JObject>();
			var toServerJson = namespaceJson["toServer"]!.ToObject<JObject>();

			IEnumerable<ParsedPacket> clientPackets = ReadPacketStructs(packetType, BoundType.Client, toClientJson).ToList();
			IEnumerable<ParsedPacket> serverPackets = ReadPacketStructs(packetType, BoundType.Server, toServerJson).ToList();

			if (debug) {
				Console.WriteLine($"* {typeNameLower}");

				if (clientPackets.Any()) {
					Console.WriteLine("   # toClient");
					foreach (var item in clientPackets) {
						Console.WriteLine($"     - {item}");
					}
				}

				if (serverPackets.Any()) {
					Console.WriteLine("   # toServer");
					foreach (var item in serverPackets) {
						Console.WriteLine($"     - {item}");
					}
				}
			}

			foreach (ParsedPacket packet in clientPackets.Concat(serverPackets)) {
				fileNameToContent[($"{packet.Type}/{packet.Bound}", $"{packet.Name}.g.cs")] = BuildCode(packet);
			}
		}


		return fileNameToContent;
	}

	private static IEnumerable<ParsedPacket> ReadPacketStructs(PacketType packetType, BoundType bound, JObject json) {
		var types = json["types"].ToObject<JObject>();
		var meta = types["packet"]!.ToObject<JArray>();

		var metaKey = meta[0].ToObject<string>();
		if (metaKey != "container")
			throw new InvalidOperationException("No meta key match!");

		var metaArray = meta[1].ToObject<JArray>();
		var idDict = metaArray[0]["type"]!.ToObject<JArray>()[1]["mappings"]!.ToObject<Dictionary<string, string>>();
		var paramsDict = metaArray[1]["type"]!.ToObject<JArray>()[1]["fields"]!.ToObject<Dictionary<string, string>>();

		foreach (var pair in types) {
			string packetName = pair.Key;
			JToken packetJson = pair.Value;

			const string packetPrefix = "packet_";
			if (!packetName.StartsWith(packetPrefix))
				continue;

			var packetKey = paramsDict.SingleOrDefault(s => s.Value == packetName).Key;
			var packetIdStr = idDict.SingleOrDefault(s => s.Value == packetKey).Key;
			var packetId = Convert.ToByte(packetIdStr.Replace("0x", ""), 16);

			var fieldListJson = packetJson.ToObject<JArray>()[1];
			var fieldList = new List<PacketField>();

			foreach (var fieldJson in fieldListJson) {
				var actualFieldName = fieldJson["name"]!.ToObject<string>();
				var fieldName = ToTitleCase(actualFieldName);
				var fieldType = fieldJson["type"];

				if (fieldType is JValue) {
					var simpleFieldType = fieldType.ToObject<string>();
					var nativeFieldType = FieldMapping.GetNative(simpleFieldType, actualFieldName);

					fieldList.Add(new PacketField {
						ActualType = simpleFieldType,
						NativeType = nativeFieldType,
						Name = fieldName
					});
				} else if (fieldType is JArray) {
					//TODO: Handle switch, option etc...
				}
			}

			yield return new ParsedPacket {
				Id = packetId,
				Type = packetType,
				Bound = bound,
				Name = ToTitleCase(packetName.Replace(packetPrefix, "")),
				Fields = fieldList
			};
		}
	}

	private static string BuildCode(ParsedPacket parsedPacket) {
		var className = $"{parsedPacket.Type}{parsedPacket.Bound}{parsedPacket.Name}";

		return $$"""
// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.{{parsedPacket.Type}};

public record {{className}} : IPacket {

    public byte PacketId => {{$"0x{parsedPacket.Id:x2}"}};

    {{string.Join("\n    ", parsedPacket.Fields.Select(f => $$"""public {{f.NativeType}} {{f.Name}} { get; private set; }"""))}}

	public {{className}}(
		{{string.Join(",\n		", parsedPacket.Fields.Select(f => $$"""{{f.NativeType}} {{ToCamelCase(f.Name)}}"""))}}
		) {
		{{string.Join("\n		", parsedPacket.Fields.Select(f => $$"""{{f.Name}} = {{ToCamelCase(f.Name)}};"""))}}
	}

	public void Serialize(IMinecraftReader reader) {
		{{string.Join("\n        ", parsedPacket.Fields.Select(f => $"{f.Name} = reader.{MethodMapping.GetReader(f.ActualType, f.Name)};"))}}
	}

	public void Deserialize(IMinecraftWriter writer) {
		{{string.Join("\n        ", parsedPacket.Fields.Select(f => $"writer.{MethodMapping.GetWriter(f.ActualType, f.Name)};"))}}
	}
}
""";
	}

	private static string ToTitleCase(string text) {
		if (string.IsNullOrWhiteSpace(text))
			return null;
		var bld = new StringBuilder();
		foreach (var part in text.Split('_')) {
			var big = part.Substring(0, 1)
				          .ToUpperInvariant() +
			          part.Substring(1);
			bld.Append(big);
		}
		var txt = bld.ToString();
		return txt;
	}

	private static string ToCamelCase(string text) {
		if (string.IsNullOrWhiteSpace(text))
			return null;
		var bld = new StringBuilder();
		foreach (var part in text.Split('_')) {
			var big = part[..1].ToUpperInvariant() + part[1..];
			bld.Append(big);
		}
		var txt = bld.ToString();
		return txt[..1].ToLowerInvariant() + txt[1..];
	}
}
