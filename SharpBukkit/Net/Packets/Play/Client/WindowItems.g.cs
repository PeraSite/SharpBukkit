// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWindowItems : IPacket {

    public byte PacketId => 0x14;

    public byte WindowId { get; private set; }
    public int StateId { get; private set; }
    public SlotData CarriedItem { get; private set; }

    public PlayClientWindowItems(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWindowItems(
		byte windowId,
		int stateId,
		SlotData carriedItem
		) {
		WindowId = windowId;
		StateId = stateId;
		CarriedItem = carriedItem;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteVarInt(StateId);
        writer.WriteSlot(CarriedItem);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        StateId = reader.ReadVarInt();
        CarriedItem = reader.ReadSlot();
	}
}
