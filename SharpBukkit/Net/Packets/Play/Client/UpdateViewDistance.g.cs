// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientUpdateViewDistance : IPacket {

    public byte PacketId => 0x4a;

    public int ViewDistance { get; private set; }

    public PlayClientUpdateViewDistance(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUpdateViewDistance(
		int viewDistance
		) {
		ViewDistance = viewDistance;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ViewDistance);
	}

	public void Deserialize(IMinecraftReader reader) {
		ViewDistance = reader.ReadVarInt();
	}
}
