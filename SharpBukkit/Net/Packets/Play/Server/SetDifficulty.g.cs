// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSetDifficulty : IPacket {

    public byte PacketId => 0x02;

    public byte NewDifficulty { get; private set; }

    public PlayServerSetDifficulty(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSetDifficulty(
		byte newDifficulty
		) {
		NewDifficulty = newDifficulty;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(NewDifficulty);
	}

	public void Deserialize(IMinecraftReader reader) {
		NewDifficulty = reader.ReadByte();
	}
}
