// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldBorderCenter : IPacket {

    public byte PacketId => 0x42;

    public double X { get; private set; }
    public double Z { get; private set; }

    public PlayClientWorldBorderCenter(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderCenter(
		double x,
		double z
		) {
		X = x;
		Z = z;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Z);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Z = reader.ReadDouble();
	}
}
