// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record StatusServerPing : IPacket {

    public byte PacketId => 0x01;

    public long Time { get; private set; }

    public StatusServerPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusServerPing(
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
