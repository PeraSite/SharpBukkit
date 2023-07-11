// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerPickItem : IPacket {

    public byte PacketId => 0x17;

    public int Slot { get; private set; }

	public PlayServerPickItem(
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
