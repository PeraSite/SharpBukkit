// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Handshaking;

public record HandshakingServerLegacyServerListPing : IPacket {

    public byte PacketId => 0xfe;

    public byte Payload { get; private set; }

    public HandshakingServerLegacyServerListPing(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public HandshakingServerLegacyServerListPing(
		byte payload
		) {
		Payload = payload;
	}

	public void Serialize(IMinecraftReader reader) {
		Payload = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(Payload);
	}
}