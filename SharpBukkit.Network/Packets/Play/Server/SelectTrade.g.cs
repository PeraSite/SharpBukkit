// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSelectTrade : IPacket {

    public byte PacketId => 0x23;

    public int Slot { get; private set; }

    public PlayServerSelectTrade(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerSelectTrade(
		int slot
		) {
		Slot = slot;
	}

	public void Serialize(IMinecraftReader reader) {
		Slot = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Slot);
	}
}