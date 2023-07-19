// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSetTitleText : IPacket {

    public byte PacketId => 0x5a;

    public string Text { get; private set; }

    public PlayClientSetTitleText(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetTitleText(
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
