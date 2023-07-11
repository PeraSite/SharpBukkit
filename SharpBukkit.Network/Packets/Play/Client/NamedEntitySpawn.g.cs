// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientNamedEntitySpawn : IPacket {

    public byte PacketId => 0x04;

    public int EntityId { get; private set; }
    public Guid PlayerUUID { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }

	public PlayClientNamedEntitySpawn(
		int entityId,
		Guid playerUUID,
		double x,
		double y,
		double z,
		sbyte yaw,
		sbyte pitch
		) {
		EntityId = entityId;
		PlayerUUID = playerUUID;
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        PlayerUUID = reader.ReadUuid();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteUuid(PlayerUUID);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
	}
}
