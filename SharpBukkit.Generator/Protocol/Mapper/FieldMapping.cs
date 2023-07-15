using System;

namespace SharpBukkit.Generator.Protocol.Mapper;

internal static class FieldMapping {
	public static string GetNative(string type, string fieldName) {
		switch (type) {
			case "varint": return "int";
			case "string": return "string";
			case "bool": return "bool";
			case "u8": return "byte";
			case "i8": return "sbyte";
			case "u16": return "ushort";
			case "i16": return "short";
			case "i32": return "int";
			case "varlong": return "long";
			case "i64": return "long";
			case "f32": return "float";
			case "f64": return "double";
			case "UUID": return "Guid";
			case "slot": return "ISlotData";
			case "buffer": return "byte[]";
			case "restBuffer": return "byte[]";
			case "optionalNbt": return "CompoundTag?";
			case "entityMetadata": return "byte[]";
			case "nbt": {
				return fieldName switch {
					"dimensionCodec" => "DimensionCodec",
					"dimension" => "Dimension",
					"heightmaps" => "Heightmaps",
					_ => "CompoundTag"
				};
			}
			case "position": return "Vector3";
			default: throw new InvalidOperationException(type);
		}
	}
}
