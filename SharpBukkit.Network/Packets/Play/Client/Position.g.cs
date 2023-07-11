// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientPosition : IPacket {

    public byte PacketId => 0x38;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public sbyte Flags { get; private set; }
    public int TeleportId { get; private set; }
    public bool DismountVehicle { get; private set; }

	public PlayClientPosition(
		double x,
		double y,
		double z,
		float yaw,
		float pitch,
		sbyte flags,
		int teleportId,
		bool dismountVehicle
		) {
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
		Flags = flags;
		TeleportId = teleportId;
		DismountVehicle = dismountVehicle;
	}

	public void Serialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        Flags = reader.ReadSByte();
        TeleportId = reader.ReadVarInt();
        DismountVehicle = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
        writer.WriteSByte(Flags);
        writer.WriteVarInt(TeleportId);
        writer.WriteBool(DismountVehicle);
	}
}
