// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityEquipment : IPacket {

    public byte PacketId => 0x50;

    public int EntityId { get; private set; }

    public PlayClientEntityEquipment(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityEquipment(
		int entityId
		) {
		EntityId = entityId;
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}
}
