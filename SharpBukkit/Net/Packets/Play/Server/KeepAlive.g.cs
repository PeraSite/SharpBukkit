// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerKeepAlive : IPacket {

    public byte PacketId => 0x0f;

    public long KeepAliveId { get; private set; }

    public PlayServerKeepAlive(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerKeepAlive(
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
