// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientKeepAlive : IPacket {

    public byte PacketId => 0x21;

    public long KeepAliveId { get; private set; }

    public PlayClientKeepAlive(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientKeepAlive(
		long keepAliveId
		) {
		KeepAliveId = keepAliveId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(KeepAliveId);
	}

	public void Deserialize(IMinecraftReader reader) {
		KeepAliveId = reader.ReadLong();
	}
}
