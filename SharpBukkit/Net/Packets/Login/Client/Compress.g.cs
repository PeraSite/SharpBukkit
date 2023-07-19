// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginClientCompress : IPacket {

    public byte PacketId => 0x03;

    public int Threshold { get; private set; }

    public LoginClientCompress(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientCompress(
		int threshold
		) {
		Threshold = threshold;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Threshold);
	}

	public void Deserialize(IMinecraftReader reader) {
		Threshold = reader.ReadVarInt();
	}
}
