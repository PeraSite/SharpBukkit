// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerArmAnimation : IPacket {

    public byte PacketId => 0x2c;

    public int Hand { get; private set; }

    public PlayServerArmAnimation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerArmAnimation(
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