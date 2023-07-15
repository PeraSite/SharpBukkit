// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSpawnEntity : IPacket {

    public byte PacketId => 0x00;

    public int EntityId { get; private set; }
    public Guid ObjectUUID { get; private set; }
    public int Type { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public sbyte Pitch { get; private set; }
    public sbyte Yaw { get; private set; }
    public int ObjectData { get; private set; }
    public short VelocityX { get; private set; }
    public short VelocityY { get; private set; }
    public short VelocityZ { get; private set; }

    public PlayClientSpawnEntity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSpawnEntity(
		int entityId,
		Guid objectUUID,
		int type,
		double x,
		double y,
		double z,
		sbyte pitch,
		sbyte yaw,
		int objectData,
		short velocityX,
		short velocityY,
		short velocityZ
		) {
		EntityId = entityId;
		ObjectUUID = objectUUID;
		Type = type;
		X = x;
		Y = y;
		Z = z;
		Pitch = pitch;
		Yaw = yaw;
		ObjectData = objectData;
		VelocityX = velocityX;
		VelocityY = velocityY;
		VelocityZ = velocityZ;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteUuid(ObjectUUID);
        writer.WriteVarInt(Type);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteSByte(Pitch);
        writer.WriteSByte(Yaw);
        writer.WriteInt(ObjectData);
        writer.WriteShort(VelocityX);
        writer.WriteShort(VelocityY);
        writer.WriteShort(VelocityZ);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        ObjectUUID = reader.ReadUuid();
        Type = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Pitch = reader.ReadSByte();
        Yaw = reader.ReadSByte();
        ObjectData = reader.ReadInt();
        VelocityX = reader.ReadShort();
        VelocityY = reader.ReadShort();
        VelocityZ = reader.ReadShort();
	}
}