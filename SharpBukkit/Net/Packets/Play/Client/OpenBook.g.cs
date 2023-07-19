// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientOpenBook : IPacket {

    public byte PacketId => 0x2d;

    public int Hand { get; private set; }

    public PlayClientOpenBook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientOpenBook(
		int hand
		) {
		Hand = hand;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Hand);
	}

	public void Deserialize(IMinecraftReader reader) {
		Hand = reader.ReadVarInt();
	}
}
