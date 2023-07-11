// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSpawnEntityExperienceOrb : IPacket {

    public byte PacketId => 0x01;

    public int EntityId { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public short Count { get; private set; }

	public PlayClientSpawnEntityExperienceOrb(
		int entityId,
		double x,
		double y,
		double z,
		short count
		) {
		EntityId = entityId;
		X = x;
		Y = y;
		Z = z;
		Count = count;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Count = reader.ReadShort();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteShort(Count);
	}
}
