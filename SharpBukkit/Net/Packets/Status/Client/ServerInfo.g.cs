// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record StatusClientServerInfo : IPacket {

    public byte PacketId => 0x00;

    public string Response { get; private set; }

    public StatusClientServerInfo(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusClientServerInfo(
		string response
		) {
		Response = response;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Response);
	}

	public void Deserialize(IMinecraftReader reader) {
		Response = reader.ReadString();
	}
}
