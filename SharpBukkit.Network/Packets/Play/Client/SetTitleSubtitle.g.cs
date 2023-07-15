// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSetTitleSubtitle : IPacket {

    public byte PacketId => 0x58;

    public string Text { get; private set; }

    public PlayClientSetTitleSubtitle(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetTitleSubtitle(
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