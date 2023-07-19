// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientHeldItemSlot : IPacket {

    public byte PacketId => 0x48;

    public sbyte Slot { get; private set; }

    public PlayClientHeldItemSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientHeldItemSlot(
		sbyte slot
		) {
		Slot = slot;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Slot);
	}

	public void Deserialize(IMinecraftReader reader) {
		Slot = reader.ReadSByte();
	}
}
