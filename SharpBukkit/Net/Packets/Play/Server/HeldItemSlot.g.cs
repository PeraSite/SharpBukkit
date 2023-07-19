// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerHeldItemSlot : IPacket {

    public byte PacketId => 0x25;

    public short SlotId { get; private set; }

    public PlayServerHeldItemSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerHeldItemSlot(
		short slotId
		) {
		SlotId = slotId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteShort(SlotId);
	}

	public void Deserialize(IMinecraftReader reader) {
		SlotId = reader.ReadShort();
	}
}
