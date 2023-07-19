// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSimulationDistance : IPacket {

    public byte PacketId => 0x57;

    public int Distance { get; private set; }

    public PlayClientSimulationDistance(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSimulationDistance(
		int distance
		) {
		Distance = distance;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Distance);
	}

	public void Deserialize(IMinecraftReader reader) {
		Distance = reader.ReadVarInt();
	}
}
