// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSetPassengers : IPacket {

    public byte PacketId => 0x54;

    public int EntityId { get; private set; }

    public PlayClientSetPassengers(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientSetPassengers(
		int entityId
		) {
		EntityId = entityId;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}
}