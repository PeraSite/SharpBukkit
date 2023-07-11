// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUpdateSign : IPacket {

    public byte PacketId => 0x2b;

    public Vector3 Location { get; private set; }
    public string Text1 { get; private set; }
    public string Text2 { get; private set; }
    public string Text3 { get; private set; }
    public string Text4 { get; private set; }

    public PlayServerUpdateSign(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUpdateSign(
		Vector3 location,
		string text1,
		string text2,
		string text3,
		string text4
		) {
		Location = location;
		Text1 = text1;
		Text2 = text2;
		Text3 = text3;
		Text4 = text4;
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Text1 = reader.ReadString();
        Text2 = reader.ReadString();
        Text3 = reader.ReadString();
        Text4 = reader.ReadString();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteString(Text1);
        writer.WriteString(Text2);
        writer.WriteString(Text3);
        writer.WriteString(Text4);
	}
}
