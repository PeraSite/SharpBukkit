// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSetCreativeSlot : IPacket {

    public byte PacketId => 0x28;

    public short Slot { get; private set; }
    public SlotData Item { get; private set; }

    public PlayServerSetCreativeSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSetCreativeSlot(
		short slot,
		SlotData item
		) {
		Slot = slot;
		Item = item;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteShort(Slot);
        writer.WriteSlot(Item);
	}

	public void Deserialize(IMinecraftReader reader) {
		Slot = reader.ReadShort();
        Item = reader.ReadSlot();
	}
}
