// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSpawnEntityLiving : IPacket {

    public byte PacketId => 0x02;

    public int EntityId { get; private set; }
    public Guid EntityUUID { get; private set; }
    public int Type { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }
    public sbyte HeadPitch { get; private set; }
    public short VelocityX { get; private set; }
    public short VelocityY { get; private set; }
    public short VelocityZ { get; private set; }

    public PlayClientSpawnEntityLiving(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSpawnEntityLiving(
		int entityId,
		Guid entityUUID,
		int type,
		double x,
		double y,
		double z,
		sbyte yaw,
		sbyte pitch,
		sbyte headPitch,
		short velocityX,
		short velocityY,
		short velocityZ
		) {
		EntityId = entityId;
		EntityUUID = entityUUID;
		Type = type;
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
		HeadPitch = headPitch;
		VelocityX = velocityX;
		VelocityY = velocityY;
		VelocityZ = velocityZ;
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        EntityUUID = reader.ReadUuid();
        Type = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
        HeadPitch = reader.ReadSByte();
        VelocityX = reader.ReadShort();
        VelocityY = reader.ReadShort();
        VelocityZ = reader.ReadShort();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteUuid(EntityUUID);
        writer.WriteVarInt(Type);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
        writer.WriteSByte(HeadPitch);
        writer.WriteShort(VelocityX);
        writer.WriteShort(VelocityY);
        writer.WriteShort(VelocityZ);
	}
}
