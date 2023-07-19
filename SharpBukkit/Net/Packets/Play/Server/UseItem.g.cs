// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerUseItem : IPacket {

    public byte PacketId => 0x2f;

    public int Hand { get; private set; }

    public PlayServerUseItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUseItem(
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
