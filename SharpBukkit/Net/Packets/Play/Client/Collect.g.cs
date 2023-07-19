// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientCollect : IPacket {

    public byte PacketId => 0x61;

    public int CollectedEntityId { get; private set; }
    public int CollectorEntityId { get; private set; }
    public int PickupItemCount { get; private set; }

    public PlayClientCollect(IMinecraftReader reader) {
	    Deserialize(reader);
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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(CollectedEntityId);
        writer.WriteVarInt(CollectorEntityId);
        writer.WriteVarInt(PickupItemCount);
	}

	public void Deserialize(IMinecraftReader reader) {
		CollectedEntityId = reader.ReadVarInt();
        CollectorEntityId = reader.ReadVarInt();
        PickupItemCount = reader.ReadVarInt();
	}
}
