// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityTeleport : IPacket {

    public byte PacketId => 0x62;

    public int EntityId { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayClientEntityTeleport(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityTeleport(
		int entityId,
		double x,
		double y,
		double z,
		sbyte yaw,
		sbyte pitch,
		bool onGround
		) {
		EntityId = entityId;
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
		OnGround = onGround;
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
        OnGround = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
        writer.WriteBool(OnGround);
	}
}
