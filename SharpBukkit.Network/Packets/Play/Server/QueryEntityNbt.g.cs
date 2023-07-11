// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerQueryEntityNbt : IPacket {

    public byte PacketId => 0x0c;

    public int TransactionId { get; private set; }
    public int EntityId { get; private set; }

    public PlayServerQueryEntityNbt(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerQueryEntityNbt(
		int transactionId,
		int entityId
		) {
		TransactionId = transactionId;
		EntityId = entityId;
	}

	public void Serialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        EntityId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteVarInt(EntityId);
	}
}