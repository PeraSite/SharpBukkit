// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record HandshakingServerSetProtocol : IPacket {

    public byte PacketId => 0x00;

    public int ProtocolVersion { get; private set; }
    public string ServerHost { get; private set; }
    public ushort ServerPort { get; private set; }
    public int NextState { get; private set; }

    public HandshakingServerSetProtocol(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public HandshakingServerSetProtocol(
		int protocolVersion,
		string serverHost,
		ushort serverPort,
		int nextState
		) {
		ProtocolVersion = protocolVersion;
		ServerHost = serverHost;
		ServerPort = serverPort;
		NextState = nextState;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ProtocolVersion);
        writer.WriteString(ServerHost);
        writer.WriteUShort(ServerPort);
        writer.WriteVarInt(NextState);
	}

	public void Deserialize(IMinecraftReader reader) {
		ProtocolVersion = reader.ReadVarInt();
        ServerHost = reader.ReadString();
        ServerPort = reader.ReadUShort();
        NextState = reader.ReadVarInt();
	}
}
