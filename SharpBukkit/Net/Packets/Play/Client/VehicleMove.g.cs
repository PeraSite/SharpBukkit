// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientVehicleMove : IPacket {

    public byte PacketId => 0x2c;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }

    public PlayClientVehicleMove(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientVehicleMove(
		double x,
		double y,
		double z,
		float yaw,
		float pitch
		) {
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}
}
