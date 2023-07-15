using System;

namespace SharpBukkit.Generator.Protocol.Mapper;

internal static class MethodMapping {
	public static string GetWriter(string type, string fieldName) {
		switch (type) {
			case "entityMetadata": return $"WriteMetadata({fieldName})";
			case "bool": return $"WriteBool({fieldName})";
			case "f32": return $"WriteFloat({fieldName})";
			case "f64": return $"WriteDouble({fieldName})";
			case "i8": return $"WriteSByte({fieldName})";
			case "i16": return $"WriteShort({fieldName})";
			case "i32": return $"WriteInt({fieldName})";
			case "i64":
			case "varlong": return $"WriteLong({fieldName})";
			case "u8": return $"WriteByte({fieldName})";
			case "u16": return $"WriteUShort({fieldName})";
			case "string": return $"WriteString({fieldName})";
			case "optionalNbt": return $"WriteOptNbtTag({fieldName})";
			case "position": return $"WritePosition({fieldName})";
			case "restBuffer": return $"WriteBuffer({fieldName})";
			case "slot": return $"WriteSlot({fieldName})";
			case "UUID": return $"WriteUuid({fieldName})";
			case "varint": return $"WriteVarInt({fieldName})";
			case "nbt": {
				return fieldName switch {
					"DimensionCodec" => $"WriteNbt<DimensionCodec>({fieldName})",
					"Dimension" => $"WriteNbt<Dimension>({fieldName})",
					"Heightmaps" => $"WriteNbt<Heightmaps>({fieldName})",
					_ => $"WriteNbtTag({fieldName})",
				};
			}
			case "buffer": return $"WriteByteArray({fieldName})";
			default: throw new InvalidOperationException(type);
		}
	}

	public static string GetReader(string type, string fieldName) {
		switch (type) {
			case "entityMetadata": return "ReadMetadata()";
			case "bool": return "ReadBool()";
			case "f32": return "ReadFloat()";
			case "f64": return "ReadDouble()";
			case "i8": return "ReadSByte()";
			case "i16": return "ReadShort()";
			case "i32": return "ReadInt()";
			case "varlong":
			case "i64": return "ReadLong()";
			case "u8": return "ReadByte()";
			case "u16": return "ReadUShort()";
			case "string": return "ReadString()";
			case "optionalNbt": return "ReadOptNbtTag()";
			case "position": return "ReadPosition()";
			case "restBuffer": return "ReadBuffer()";
			case "slot": return "ReadSlot()";
			case "UUID": return "ReadUuid()";
			case "varint": return "ReadVarInt()";
			case "nbt": {
				return fieldName switch {
					"DimensionCodec" => "ReadNbt<DimensionCodec>()",
					"Dimension" => "ReadNbt<Dimension>()",
					"Heightmaps" => "ReadNbt<Heightmaps>()",
					_ => throw new InvalidOperationException(type)
				};
			}
			case "buffer": return "ReadByteArray()";
			default: throw new InvalidOperationException(type);
		}
	}
}
