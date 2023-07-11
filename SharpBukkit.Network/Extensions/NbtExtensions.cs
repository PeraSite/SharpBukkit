using SharpBukkit.Network.API.Serialization;
using SharpNBT;

namespace SharpBukkit.Network.Extensions;

public static class NbtExtensions {
	public static CompoundTag? ReadCompoundTag(this Stream stream, FormatOptions formatOption) {
		using var reader = new TagReader(stream, formatOption, true);
		var rawTag = reader.ReadTag();

		if (rawTag == null) {
			return null;
		}

		if (rawTag is EndTag) {
			return null;
		}

		return (CompoundTag)rawTag;
	}

	public static void WriteCompoundTag(this Stream stream, CompoundTag tag, FormatOptions formatOption) {
		using var writer = new TagWriter(stream, formatOption, true);
		writer.WriteCompound(tag);
	}

	public static T ToObject<T>(this CompoundTag tag) where T : INbtSerializable, new() {
		var obj = new T();
		obj.Deserialize(tag);
		return obj;
	}

	public static Dictionary<string, object> ToDictionary(this CompoundTag tag) {
		return tag.ToDictionary(k => k.Name, ToValue);
	}

	private static object ToValue(Tag tag) {
		var kind = tag.Type;
		return kind switch {
			TagType.Byte => ((ByteTag)tag).Value,
			TagType.Int => ((IntTag)tag).Value,
			TagType.Float => ((FloatTag)tag).Value,
			TagType.Double => ((DoubleTag)tag).Value,
			TagType.String => ((StringTag)tag).Value,
			TagType.Short => ((ShortTag)tag).Value,
			TagType.Long => ((LongTag)tag).Value,
			TagType.Compound => ((CompoundTag)tag).ToDictionary(),
			_ => throw new InvalidOperationException($"Invalid tag type: {kind}")
		};
	}
}
