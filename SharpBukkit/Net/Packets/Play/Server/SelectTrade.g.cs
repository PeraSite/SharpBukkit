// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSelectTrade : IPacket {

    public byte PacketId => 0x23;

    public int Slot { get; private set; }

    public PlayServerSelectTrade(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSelectTrade(
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
