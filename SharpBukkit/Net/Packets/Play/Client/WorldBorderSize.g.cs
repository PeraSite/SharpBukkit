// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldBorderSize : IPacket {

    public byte PacketId => 0x44;

    public double Diameter { get; private set; }

    public PlayClientWorldBorderSize(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderSize(
		double diameter
		) {
		Diameter = diameter;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(Diameter);
	}

	public void Deserialize(IMinecraftReader reader) {
		Diameter = reader.ReadDouble();
	}
}
