// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerPosition : IPacket {

    public byte PacketId => 0x11;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public bool OnGround { get; private set; }

    public PlayServerPosition(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPosition(
		double x,
		double y,
		double z,
		bool onGround
		) {
		X = x;
		Y = y;
		Z = z;
		OnGround = onGround;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteBool(OnGround);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        OnGround = reader.ReadBool();
	}
}
