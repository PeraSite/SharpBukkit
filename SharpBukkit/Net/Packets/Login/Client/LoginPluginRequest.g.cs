// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginClientLoginPluginRequest : IPacket {

    public byte PacketId => 0x04;

    public int MessageId { get; private set; }
    public string Channel { get; private set; }
    public byte[] Data { get; private set; }

    public LoginClientLoginPluginRequest(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientLoginPluginRequest(
		int messageId,
		string channel,
		byte[] data
		) {
		MessageId = messageId;
		Channel = channel;
		Data = data;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(MessageId);
        writer.WriteString(Channel);
        writer.WriteBuffer(Data);
	}

	public void Deserialize(IMinecraftReader reader) {
		MessageId = reader.ReadVarInt();
        Channel = reader.ReadString();
        Data = reader.ReadBuffer();
	}
}
