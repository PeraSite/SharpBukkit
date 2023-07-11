// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerAdvancementTab : IPacket {

    public byte PacketId => 0x22;

    public int Action { get; private set; }

    public PlayServerAdvancementTab(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerAdvancementTab(
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