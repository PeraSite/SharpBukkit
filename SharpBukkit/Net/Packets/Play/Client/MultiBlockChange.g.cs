// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientMultiBlockChange : IPacket {

    public byte PacketId => 0x3f;

    public bool NotTrustEdges { get; private set; }

    public PlayClientMultiBlockChange(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientMultiBlockChange(
		bool notTrustEdges
		) {
		NotTrustEdges = notTrustEdges;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(NotTrustEdges);
	}

	public void Deserialize(IMinecraftReader reader) {
		NotTrustEdges = reader.ReadBool();
	}
}
