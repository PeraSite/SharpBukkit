// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerTabComplete : IPacket {

    public byte PacketId => 0x06;

    public int TransactionId { get; private set; }
    public string Text { get; private set; }

	public PlayServerTabComplete(
		int transactionId,
		string text
		) {
		TransactionId = transactionId;
		Text = text;
	}

	public void Serialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        Text = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WriteString(Text);
	}
}
