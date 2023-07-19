// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientAdvancements : IPacket {

    public byte PacketId => 0x63;

    public bool Reset { get; private set; }
    public string[] Identifiers { get; private set; }

    public PlayClientAdvancements(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAdvancements(
		bool reset,
		string[] identifiers
		) {
		Reset = reset;
		Identifiers = identifiers;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Reset);
        writer.WriteStringArray(Identifiers);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reset = reader.ReadBool();
        Identifiers = reader.ReadStringArray();
	}
}
