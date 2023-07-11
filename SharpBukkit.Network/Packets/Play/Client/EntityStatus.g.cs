// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityStatus : IPacket {

    public byte PacketId => 0x1b;

    public int EntityId { get; private set; }
    public sbyte EntityStatus { get; private set; }

    public PlayClientEntityStatus(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientEntityStatus(
		int entityId,
		sbyte entityStatus
		) {
		EntityId = entityId;
		EntityStatus = entityStatus;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadInt();
        EntityStatus = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(EntityId);
        writer.WriteSByte(EntityStatus);
	}
}