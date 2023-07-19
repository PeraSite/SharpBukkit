// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}
}
