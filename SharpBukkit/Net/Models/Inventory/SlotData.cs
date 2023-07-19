using SharpBukkit.Net.Serialization;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Models;

public class SlotData : IMinecraftSerializable {
	public bool Present { get; set; }
	public int? ItemId { get; set; }
	public byte? ItemCount { get; set; }
	public CompoundTag? Optional { get; set; }

	public void Deserialize(IMinecraftReader reader) {
		Present = reader.ReadBool();
		if (!Present)
			return;
		ItemId = reader.ReadVarInt();
		ItemCount = reader.ReadByte();
		Optional = reader.ReadOptNbtTag();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Present);
		if (!Present)
			return;
		writer.WriteVarInt(ItemId.GetValueOrDefault());
		writer.WriteByte(ItemCount.GetValueOrDefault());
		writer.WriteOptNbtTag(Optional);
	}
}
