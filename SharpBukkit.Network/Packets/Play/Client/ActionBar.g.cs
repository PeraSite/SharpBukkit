// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientActionBar : IPacket {

    public byte PacketId => 0x41;

    public string Text { get; private set; }

    public PlayClientActionBar(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientActionBar(
		string text
		) {
		Text = text;
	}

	public void Serialize(IMinecraftReader reader) {
		Text = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Text);
	}
}