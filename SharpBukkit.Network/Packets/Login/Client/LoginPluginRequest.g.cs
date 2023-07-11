// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginClientLoginPluginRequest : IPacket {

    public byte PacketId => 0x04;

    public int MessageId { get; private set; }
    public string Channel { get; private set; }
    public byte[] Data { get; private set; }

	public LoginClientLoginPluginRequest(
		int messageId,
		string channel,
		byte[] data
		) {
		MessageId = messageId;
		Channel = channel;
		Data = data;
	}

	public void Serialize(IMinecraftReader reader) {
		MessageId = reader.ReadVarInt();
        Channel = reader.ReadString();
        Data = reader.ReadBuffer();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(MessageId);
        writer.WriteString(Channel);
        writer.WriteBuffer(Data);
	}
}
