// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUseItem : IPacket {

    public byte PacketId => 0x2f;

    public int Hand { get; private set; }

    public PlayServerUseItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUseItem(
		int hand
		) {
		Hand = hand;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Hand);
	}

	public void Deserialize(IMinecraftReader reader) {
		Hand = reader.ReadVarInt();
	}
}