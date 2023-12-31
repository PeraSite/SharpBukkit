// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityVelocity : IPacket {

    public byte PacketId => 0x4f;

    public int EntityId { get; private set; }
    public short VelocityX { get; private set; }
    public short VelocityY { get; private set; }
    public short VelocityZ { get; private set; }

    public PlayClientEntityVelocity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityVelocity(
		int entityId,
		short velocityX,
		short velocityY,
		short velocityZ
		) {
		EntityId = entityId;
		VelocityX = velocityX;
		VelocityY = velocityY;
		VelocityZ = velocityZ;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteShort(VelocityX);
        writer.WriteShort(VelocityY);
        writer.WriteShort(VelocityZ);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        VelocityX = reader.ReadShort();
        VelocityY = reader.ReadShort();
        VelocityZ = reader.ReadShort();
	}
}
