// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginServerLoginPluginResponse : IPacket {

    public byte PacketId => 0x02;

    public int MessageId { get; private set; }

    public LoginServerLoginPluginResponse(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginServerLoginPluginResponse(
		int messageId
		) {
		MessageId = messageId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(MessageId);
	}

	public void Deserialize(IMinecraftReader reader) {
		MessageId = reader.ReadVarInt();
	}
}
