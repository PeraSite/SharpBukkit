// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientTabComplete : IPacket {

    public byte PacketId => 0x11;

    public int TransactionId { get; private set; }
    public int Start { get; private set; }
    public int Length { get; private set; }

	public PlayClientTabComplete(
		int transactionId,
		int start,
		int length
		) {
		TransactionId = transactionId;
		Start = start;
		Length = length;
	}

	public void Serialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        Start = reader.ReadVarInt();
        Length = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteVarInt(Start);
        writer.WriteVarInt(Length);
	}
}
