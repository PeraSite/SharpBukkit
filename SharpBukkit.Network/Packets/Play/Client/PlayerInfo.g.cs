// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientPlayerInfo : IPacket {

    public byte PacketId => 0x36;

    public int Action { get; private set; }

    public PlayClientPlayerInfo(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientPlayerInfo(
		int action
		) {
		Action = action;
	}

	public void Serialize(IMinecraftReader reader) {
		Action = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Action);
	}
}