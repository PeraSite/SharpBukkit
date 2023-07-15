// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityHeadRotation : IPacket {

    public byte PacketId => 0x3e;

    public int EntityId { get; private set; }
    public sbyte HeadYaw { get; private set; }

    public PlayClientEntityHeadRotation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityHeadRotation(
		int entityId,
		sbyte headYaw
		) {
		EntityId = entityId;
		HeadYaw = headYaw;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteSByte(HeadYaw);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        HeadYaw = reader.ReadSByte();
	}
}