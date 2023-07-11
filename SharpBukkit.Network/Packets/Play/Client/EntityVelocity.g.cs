// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityVelocity : IPacket {

    public byte PacketId => 0x4f;

    public int EntityId { get; private set; }
    public short VelocityX { get; private set; }
    public short VelocityY { get; private set; }
    public short VelocityZ { get; private set; }

    public PlayClientEntityVelocity(IMinecraftReader reader) {
	    Serialize(reader);
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

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        VelocityX = reader.ReadShort();
        VelocityY = reader.ReadShort();
        VelocityZ = reader.ReadShort();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteShort(VelocityX);
        writer.WriteShort(VelocityY);
        writer.WriteShort(VelocityZ);
	}
}