// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientFacePlayer : IPacket {

    public byte PacketId => 0x37;

    public int FeetEyes { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public bool IsEntity { get; private set; }

    public PlayClientFacePlayer(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientFacePlayer(
		int feetEyes,
		double x,
		double y,
		double z,
		bool isEntity
		) {
		FeetEyes = feetEyes;
		X = x;
		Y = y;
		Z = z;
		IsEntity = isEntity;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(FeetEyes);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteBool(IsEntity);
	}

	public void Deserialize(IMinecraftReader reader) {
		FeetEyes = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        IsEntity = reader.ReadBool();
	}
}
