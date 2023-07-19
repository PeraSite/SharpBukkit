// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerArmAnimation : IPacket {

    public byte PacketId => 0x2c;

    public int Hand { get; private set; }

    public PlayServerArmAnimation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerArmAnimation(
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
