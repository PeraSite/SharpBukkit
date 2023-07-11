// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientFacePlayer : IPacket {

    public byte PacketId => 0x37;

    public int FeetEyes { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public bool IsEntity { get; private set; }

    public PlayClientFacePlayer(IMinecraftReader reader) {
	    Serialize(reader);
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

	public void Serialize(IMinecraftReader reader) {
		FeetEyes = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        IsEntity = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(FeetEyes);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteBool(IsEntity);
	}
}