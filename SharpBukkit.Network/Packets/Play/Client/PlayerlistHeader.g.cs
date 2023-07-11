// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientPlayerlistHeader : IPacket {

    public byte PacketId => 0x5f;

    public string Header { get; private set; }
    public string Footer { get; private set; }

    public PlayClientPlayerlistHeader(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientPlayerlistHeader(
		string header,
		string footer
		) {
		Header = header;
		Footer = footer;
	}

	public void Serialize(IMinecraftReader reader) {
		Header = reader.ReadString();
        Footer = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Header);
        writer.WriteString(Footer);
	}
}