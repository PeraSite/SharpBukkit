// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerQueryEntityNbt : IPacket {

    public byte PacketId => 0x0c;

    public int TransactionId { get; private set; }
    public int EntityId { get; private set; }

    public PlayServerQueryEntityNbt(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerQueryEntityNbt(
		int transactionId,
		int entityId
		) {
		TransactionId = transactionId;
		EntityId = entityId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteVarInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        EntityId = reader.ReadVarInt();
	}
}
