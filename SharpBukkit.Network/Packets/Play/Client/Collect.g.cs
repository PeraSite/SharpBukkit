// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCollect : IPacket {

    public byte PacketId => 0x61;

    public int CollectedEntityId { get; private set; }
    public int CollectorEntityId { get; private set; }
    public int PickupItemCount { get; private set; }

    public PlayClientCollect(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientCollect(
		int collectedEntityId,
		int collectorEntityId,
		int pickupItemCount
		) {
		CollectedEntityId = collectedEntityId;
		CollectorEntityId = collectorEntityId;
		PickupItemCount = pickupItemCount;
	}

	public void Serialize(IMinecraftReader reader) {
		CollectedEntityId = reader.ReadVarInt();
        CollectorEntityId = reader.ReadVarInt();
        PickupItemCount = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(CollectedEntityId);
        writer.WriteVarInt(CollectorEntityId);
        writer.WriteVarInt(PickupItemCount);
	}
}