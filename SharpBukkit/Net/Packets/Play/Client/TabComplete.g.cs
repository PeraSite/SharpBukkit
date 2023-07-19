// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientTabComplete : IPacket {

    public byte PacketId => 0x11;

    public int TransactionId { get; private set; }
    public int Start { get; private set; }
    public int Length { get; private set; }

    public PlayClientTabComplete(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientTabComplete(
		int transactionId,
		int start,
		int length
		) {
		TransactionId = transactionId;
		Start = start;
		Length = length;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteVarInt(Start);
        writer.WriteVarInt(Length);
	}

	public void Deserialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        Start = reader.ReadVarInt();
        Length = reader.ReadVarInt();
	}
}
