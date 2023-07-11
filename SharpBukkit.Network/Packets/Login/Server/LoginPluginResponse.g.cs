// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginServerLoginPluginResponse : IPacket {

    public byte PacketId => 0x02;

    public int MessageId { get; private set; }

    public LoginServerLoginPluginResponse(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public LoginServerLoginPluginResponse(
		int messageId
		) {
		MessageId = messageId;
	}

	public void Serialize(IMinecraftReader reader) {
		MessageId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(MessageId);
	}
}