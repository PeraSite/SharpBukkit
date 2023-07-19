// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientActionBar : IPacket {

    public byte PacketId => 0x41;

    public string Text { get; private set; }

    public PlayClientActionBar(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientActionBar(
		string text
		) {
		Text = text;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Text);
	}

	public void Deserialize(IMinecraftReader reader) {
		Text = reader.ReadString();
	}
}
