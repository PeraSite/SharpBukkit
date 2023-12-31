// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerPositionLook : IPacket {

    public byte PacketId => 0x12;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayServerPositionLook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPositionLook(
		double x,
		double y,
		double z,
		float yaw,
		float pitch,
		bool onGround
		) {
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
		OnGround = onGround;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
        writer.WriteBool(OnGround);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        OnGround = reader.ReadBool();
	}
}
