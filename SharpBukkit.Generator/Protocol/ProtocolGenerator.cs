using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SharpBukkit.Generator.Protocol.Mapper;

namespace SharpBukkit.Generator.Protocol;

public static class ProtocolGenerator {
	public static async Task Generate(string outputFolder, string protocolJson) {
		Log.Information("Parsing JSON...");
		#region Parsing JSON
		var json = JsonConvert.DeserializeObject<JObject>(protocolJson);
		if (json == null) {
			throw new InvalidOperationException("Empty JSON!");
		}
#endregion

		var packetTypes = new[] {PacketType.Handshaking, PacketType.Status, PacketType.Login, PacketType.Play};

		Log.Information("Generating codes...");
		#region Generating code
		var generatedCodeDict = new Dictionary<PacketInfo, string>();
		foreach (PacketType packetType in packetTypes) {
			var typeName = Enum.GetName(typeof(PacketType), packetType)!;
			var packetName = typeName.ToLower();

			if (!json.TryGetValue(packetName, out var namespaceJson)) {
				throw new Exception($"Can't find packet type: {packetName}");
			}

			var toClientJson = namespaceJson["toClient"]!.ToObject<JObject>()!;
			var toServerJson = namespaceJson["toServer"]!.ToObject<JObject>()!;

			IEnumerable<PacketInfo> clientPackets = ReadPacketStructs(packetType, BoundType.Client, toClientJson).ToList();
			IEnumerable<PacketInfo> serverPackets = ReadPacketStructs(packetType, BoundType.Server, toServerJson).ToList();

			Log.Information("* {PacketType}", packetName);

			if (clientPackets.Any()) {
				Log.Information("   # toClient");
				foreach (var item in clientPackets) {
					Log.Information("     - {Packet}", item);
				}
			}

			if (serverPackets.Any()) {
				Log.Information("   # toServer");
				foreach (var item in serverPackets) {
					Log.Information("     - {Packet}", item);
				}
			}

			foreach (PacketInfo packet in clientPackets.Concat(serverPackets)) {
				generatedCodeDict[packet] = BuildCode(packet);
			}
		}
#endregion

		Log.Information("Writing to files...");
		#region Writing to file
		await Task.WhenAll(generatedCodeDict.Select(pair => {
			var (packet, content) = pair;

			var directoryName = $"{packet.Type}/{packet.Bound}";
			var fileName = $"{packet.Name}.g.cs";

			Directory.CreateDirectory(Path.Combine(outputFolder, directoryName));
			var output = Path.Combine(outputFolder, directoryName, fileName);
			Log.Information("* {DirectoryName} - {FileName}", directoryName, fileName);

			return File.WriteAllTextAsync(output, content);
		}));
  #endregion

		Log.Information("Generating packet registry...");
		#region Generating packet registry
		var registryFilePath = Path.Combine(outputFolder, "PacketRegistry.g.cs");
		await File.WriteAllTextAsync(registryFilePath, $$"""
// Auto-generated
using System;
using System.Collections.Generic;
using SharpBukkit.Net;
using SharpBukkit.Net.Utils;

namespace SharpBukkit.Net.Packets;

public class PacketRegistry {
	private readonly Dictionary<(ConnectionState state, byte id), Func<IMinecraftReader, IPacket>> _factory;

	public PacketRegistry() {
		_factory = new Dictionary<(ConnectionState state, byte id), Func<IMinecraftReader, IPacket>>();
	}

	public void Load() {
		{{string.Join("\n        ", generatedCodeDict.Keys.Select(packet => $"Register(ConnectionState.{packet.Type}, 0x{packet.Id:x2}, (reader) => new {packet.Type}{packet.Bound}{packet.Name}(reader));"))}}
	}

	public IPacket Create(IMinecraftReader reader, ConnectionState state, byte id) {
		if (!_factory.TryGetValue((state, id), out Func<IMinecraftReader, IPacket> func)) {
			throw new Exception($"Unknown packet id {id} for state {state}");
		}
		return func(reader);
	}

	private void Register(ConnectionState state, byte id, Func<IMinecraftReader, IPacket> createFunc) {
		_factory[(state, id)] = createFunc;
	}
}

""");
  #endregion

		Log.Information("Done!");
	}

	private static IEnumerable<PacketInfo> ReadPacketStructs(PacketType packetType, BoundType bound, JObject json) {
		var types = json["types"]!.ToObject<JObject>()!;
		var meta = types["packet"]!.ToObject<JArray>()!;

		var metaKey = meta[0].ToObject<string>();
		if (metaKey != "container")
			throw new InvalidOperationException("No meta key match!");

		var metaArray = meta[1].ToObject<JArray>()!;
		var idDict = metaArray[0]["type"]!.ToObject<JArray>()![1]["mappings"]!.ToObject<Dictionary<string, string>>()!;
		var paramsDict = metaArray[1]["type"]!.ToObject<JArray>()![1]["fields"]!.ToObject<Dictionary<string, string>>()!;

		foreach (var pair in types) {
			string packetName = pair.Key;
			JToken packetJson = pair.Value!;

			const string packetPrefix = "packet_";
			if (!packetName.StartsWith(packetPrefix))
				continue;

			var packetKey = paramsDict.SingleOrDefault(s => s.Value == packetName).Key;
			var packetIdStr = idDict.SingleOrDefault(s => s.Value == packetKey).Key;
			var packetId = Convert.ToByte(packetIdStr.Replace("0x", ""), 16);

			var fieldListJson = packetJson.ToObject<JArray>()![1];
			List<FieldInfo> fieldList = ParsePacketFields(fieldListJson, packetName);

			yield return new PacketInfo {
				Id = packetId,
				Type = packetType,
				Bound = bound,
				Name = ToTitleCase(packetName.Replace(packetPrefix, "")),
				Fields = fieldList
			};
		}
	}

	private static List<FieldInfo> ParsePacketFields(JToken fieldListJson, string packetName) {
		var fieldList = new List<FieldInfo>();

		foreach (var fieldJson in fieldListJson) {
			var actualFieldName = fieldJson["name"]!.ToObject<string>()!;
			var fieldName = ToTitleCase(actualFieldName);
			var fieldType = fieldJson["type"];

			switch (fieldType) {
				case JValue: {
					var simpleFieldType = fieldType.ToObject<string>();
					var nativeFieldType = FieldMapping.GetNative(simpleFieldType, actualFieldName);

					if (nativeFieldType == null) {
						Log.Warning("Unknown field type {FieldType} for {FieldName}: {Raw}", simpleFieldType, actualFieldName, fieldJson.ToString());
						break;
					}

					fieldList.Add(new FieldInfo {
						ActualType = simpleFieldType,
						NativeType = nativeFieldType,
						Name = fieldName
					});
					break;
				}
				case JArray typeArray: {
					var typeName = typeArray[0].ToObject<string>();
					switch (typeName) {
						case "buffer": {
							const string actualElementType = "buffer";
							var nativeElementType = FieldMapping.GetNative(actualElementType, actualFieldName);

							if (nativeElementType == null) {
								Log.Warning("[{Packet}] Unknown field type {FieldType} for {FieldName}: {Raw}", packetName, actualElementType, actualFieldName, fieldJson.ToString());
								break;
							}

							fieldList.Add(new FieldInfo {
								ActualType = actualElementType,
								NativeType = nativeElementType,
								Name = fieldName
							});
							break;
						}
						case "array": {
							var elementTypeJson = typeArray[1]["type"];
							switch (elementTypeJson) {
								case JValue valueJson: {
									var actualElementType = $"{valueJson.ToObject<string>()}[]";
									var nativeElementType = FieldMapping.GetNative(actualElementType, actualFieldName);

									if (nativeElementType == null) {
										Log.Warning("[{Packet}] Unknown field type {FieldType} for {FieldName}: {Raw}", packetName, actualElementType, actualFieldName, fieldJson.ToString());
										break;
									}

									fieldList.Add(new FieldInfo {
										ActualType = actualElementType,
										NativeType = nativeElementType,
										Name = fieldName
									});
									break;
								}
								case JArray:
									//TODO: Handle array of complex types
									break;
							}
							break;
						}
						// TODO: handles more types
						default:
							Log.Warning("[{Packet}] Unknown field type {FieldType} for {FieldName}: {Raw}", packetName, typeName, actualFieldName, fieldJson.ToString());
							break;
					}
					break;
				}
			}
		}
		return fieldList;
	}

	private static string BuildCode(PacketInfo packetInfo) {
		var className = $"{packetInfo.Type}{packetInfo.Bound}{packetInfo.Name}";

		return $$"""
// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record {{className}} : IPacket {

    public byte PacketId => {{$"0x{packetInfo.Id:x2}"}};

    {{string.Join("\n    ", packetInfo.Fields.Select(f => $$"""public {{f.NativeType}} {{f.Name}} { get; private set; }"""))}}

    public {{className}}(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public {{className}}(
		{{string.Join(",\n		", packetInfo.Fields.Select(f => $$"""{{f.NativeType}} {{ToCamelCase(f.Name)}}"""))}}
		) {
		{{string.Join("\n		", packetInfo.Fields.Select(f => $$"""{{f.Name}} = {{ToCamelCase(f.Name)}};"""))}}
	}

	public void Serialize(IMinecraftWriter writer) {
		{{string.Join("\n        ", packetInfo.Fields.Select(f => $"writer.{MethodMapping.GetWriter(f.ActualType, f.Name)};"))}}
	}

	public void Deserialize(IMinecraftReader reader) {
		{{string.Join("\n        ", packetInfo.Fields.Select(f => $"{f.Name} = reader.{MethodMapping.GetReader(f.ActualType, f.Name)};"))}}
	}
}
""";
	}

	private static string ToTitleCase(string text) {
		if (string.IsNullOrWhiteSpace(text))
			return string.Empty;
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
			return string.Empty;
		var bld = new StringBuilder();
		foreach (var part in text.Split('_')) {
			var big = part[..1].ToUpperInvariant() + part[1..];
			bld.Append(big);
		}
		var txt = bld.ToString();
		return txt[..1].ToLowerInvariant() + txt[1..];
	}
}
