// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record StatusClientPing : IPacket {

    public byte PacketId => 0x01;

    public long Time { get; private set; }

    public StatusClientPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusClientPing(
		long time
		) {
		Time = time;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(Time);
	}

	public void Deserialize(IMinecraftReader reader) {
		Time = reader.ReadLong();
	}
}
