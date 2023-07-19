// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSetSlot : IPacket {

    public byte PacketId => 0x16;

    public sbyte WindowId { get; private set; }
    public int StateId { get; private set; }
    public short Slot { get; private set; }
    public SlotData Item { get; private set; }

    public PlayClientSetSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetSlot(
		sbyte windowId,
		int stateId,
		short slot,
		SlotData item
		) {
		WindowId = windowId;
		StateId = stateId;
		Slot = slot;
		Item = item;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteVarInt(StateId);
        writer.WriteShort(Slot);
        writer.WriteSlot(Item);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        StateId = reader.ReadVarInt();
        Slot = reader.ReadShort();
        Item = reader.ReadSlot();
	}
}
