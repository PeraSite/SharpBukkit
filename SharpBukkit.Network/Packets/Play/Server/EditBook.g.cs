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

    public PlayServerEditBook(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerEditBook(
		int hand
		) {
		Hand = hand;
	}

	public void Serialize(IMinecraftReader reader) {
		Hand = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Hand);
	}
}