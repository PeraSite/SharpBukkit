// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientClearTitles : IPacket {

    public byte PacketId => 0x10;

    public bool Reset { get; private set; }

    public PlayClientClearTitles(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientClearTitles(
		bool reset
		) {
		Reset = reset;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Reset);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reset = reader.ReadBool();
	}
}
