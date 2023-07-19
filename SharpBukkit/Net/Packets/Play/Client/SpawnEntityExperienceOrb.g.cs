// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSpawnEntityExperienceOrb : IPacket {

    public byte PacketId => 0x01;

    public int EntityId { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public short Count { get; private set; }

    public PlayClientSpawnEntityExperienceOrb(IMinecraftReader reader) {
	    Deserialize(reader);
    }

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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteShort(Count);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Count = reader.ReadShort();
	}
}
