// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSetPassengers : IPacket {

    public byte PacketId => 0x54;

    public int EntityId { get; private set; }

    public PlayClientSetPassengers(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetPassengers(
		int entityId
		) {
		EntityId = entityId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}
}
