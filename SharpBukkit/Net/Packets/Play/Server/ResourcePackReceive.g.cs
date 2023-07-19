// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerResourcePackReceive : IPacket {

    public byte PacketId => 0x21;

    public int Result { get; private set; }

    public PlayServerResourcePackReceive(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerResourcePackReceive(
		int result
		) {
		Result = result;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Result);
	}

	public void Deserialize(IMinecraftReader reader) {
		Result = reader.ReadVarInt();
	}
}
