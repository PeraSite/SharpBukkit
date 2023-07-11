// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientOpenBook : IPacket {

    public byte PacketId => 0x2d;

    public int Hand { get; private set; }

	public PlayClientOpenBook(
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
