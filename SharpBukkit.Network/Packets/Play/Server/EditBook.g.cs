// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerEditBook : IPacket {

    public byte PacketId => 0x0b;

    public int Hand { get; private set; }
    public string[] Pages { get; private set; }

    public PlayServerEditBook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerEditBook(
		int hand,
		string[] pages
		) {
		Hand = hand;
		Pages = pages;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Hand);
        writer.WriteStringArray(Pages);
	}

	public void Deserialize(IMinecraftReader reader) {
		Hand = reader.ReadVarInt();
        Pages = reader.ReadStringArray();
	}
}