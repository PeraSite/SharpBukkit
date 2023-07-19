// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerChat : IPacket {

    public byte PacketId => 0x03;

    public string Message { get; private set; }

    public PlayServerChat(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerChat(
		string message
		) {
		Message = message;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Message);
	}

	public void Deserialize(IMinecraftReader reader) {
		Message = reader.ReadString();
	}
}
