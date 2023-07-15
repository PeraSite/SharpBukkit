// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientNbtQueryResponse : IPacket {

    public byte PacketId => 0x60;

    public int TransactionId { get; private set; }
    public CompoundTag? Nbt { get; private set; }

    public PlayClientNbtQueryResponse(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientNbtQueryResponse(
		int transactionId,
		CompoundTag? nbt
		) {
		TransactionId = transactionId;
		Nbt = nbt;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteOptNbtTag(Nbt);
	}

	public void Deserialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        Nbt = reader.ReadOptNbtTag();
	}
}