// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientKickDisconnect : IPacket {

    public byte PacketId => 0x1a;

    public string Reason { get; private set; }

    public PlayClientKickDisconnect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientKickDisconnect(
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
