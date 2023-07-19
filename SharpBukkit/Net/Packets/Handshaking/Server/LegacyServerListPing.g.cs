// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record HandshakingServerLegacyServerListPing : IPacket {

    public byte PacketId => 0xfe;

    public byte Payload { get; private set; }

    public HandshakingServerLegacyServerListPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public HandshakingServerLegacyServerListPing(
		byte payload
		) {
		Payload = payload;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(Payload);
	}

	public void Deserialize(IMinecraftReader reader) {
		Payload = reader.ReadByte();
	}
}
