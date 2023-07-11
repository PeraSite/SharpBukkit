// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientHeldItemSlot : IPacket {

    public byte PacketId => 0x48;

    public sbyte Slot { get; private set; }

	public PlayClientHeldItemSlot(
		sbyte slot
		) {
		Slot = slot;
	}

	public void Serialize(IMinecraftReader reader) {
		Slot = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteSByte(Slot);
	}
}
