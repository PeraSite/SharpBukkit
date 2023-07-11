// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSetTitleText : IPacket {

    public byte PacketId => 0x5a;

    public string Text { get; private set; }

	public PlayClientSetTitleText(
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
