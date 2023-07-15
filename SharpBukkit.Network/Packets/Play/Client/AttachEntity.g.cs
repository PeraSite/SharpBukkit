// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientAttachEntity : IPacket {

    public byte PacketId => 0x4e;

    public int EntityId { get; private set; }
    public int VehicleId { get; private set; }

    public PlayClientAttachEntity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAttachEntity(
		int entityId,
		int vehicleId
		) {
		EntityId = entityId;
		VehicleId = vehicleId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(EntityId);
        writer.WriteInt(VehicleId);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadInt();
        VehicleId = reader.ReadInt();
	}
}