// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSpectate : IPacket {

    public byte PacketId => 0x2d;

    public Guid Target { get; private set; }

    public PlayServerSpectate(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSpectate(
		Guid target
		) {
		Target = target;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteUuid(Target);
	}

	public void Deserialize(IMinecraftReader reader) {
		Target = reader.ReadUuid();
	}
}
