// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientPlayerInfo : IPacket {

    public byte PacketId => 0x36;

    public int Action { get; private set; }

    public PlayClientPlayerInfo(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientPlayerInfo(
		int action
		) {
		Action = action;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Action);
	}

	public void Deserialize(IMinecraftReader reader) {
		Action = reader.ReadVarInt();
	}
}
