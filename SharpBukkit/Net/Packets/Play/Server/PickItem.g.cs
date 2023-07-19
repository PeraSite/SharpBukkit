// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerPickItem : IPacket {

    public byte PacketId => 0x17;

    public int Slot { get; private set; }

    public PlayServerPickItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPickItem(
		int slot
		) {
		Slot = slot;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Slot);
	}

	public void Deserialize(IMinecraftReader reader) {
		Slot = reader.ReadVarInt();
	}
}
