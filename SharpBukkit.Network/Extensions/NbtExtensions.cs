using SharpNBT;

namespace SharpBukkit.Network.Extensions;

public static class NbtExtensions {
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
