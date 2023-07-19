// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientPlayerlistHeader : IPacket {

    public byte PacketId => 0x5f;

    public string Header { get; private set; }
    public string Footer { get; private set; }

    public PlayClientPlayerlistHeader(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientPlayerlistHeader(
		string header,
		string footer
		) {
		Header = header;
		Footer = footer;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Header);
        writer.WriteString(Footer);
	}

	public void Deserialize(IMinecraftReader reader) {
		Header = reader.ReadString();
        Footer = reader.ReadString();
	}
}
