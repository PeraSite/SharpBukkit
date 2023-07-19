// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginClientDisconnect : IPacket {

    public byte PacketId => 0x00;

    public string Reason { get; private set; }

    public LoginClientDisconnect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientDisconnect(
		string reason
		) {
		Reason = reason;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Reason);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reason = reader.ReadString();
	}
}
