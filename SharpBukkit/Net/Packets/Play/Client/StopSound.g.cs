// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientStopSound : IPacket {

    public byte PacketId => 0x5e;

    public sbyte Flags { get; private set; }

    public PlayClientStopSound(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientStopSound(
		sbyte flags
		) {
		Flags = flags;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Flags);
	}

	public void Deserialize(IMinecraftReader reader) {
		Flags = reader.ReadSByte();
	}
}
