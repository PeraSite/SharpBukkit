// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientHeldItemSlot : IPacket {

    public byte PacketId => 0x48;

    public sbyte Slot { get; private set; }

    public PlayClientHeldItemSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientHeldItemSlot(
		sbyte slot
		) {
		Slot = slot;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Slot);
	}

	public void Deserialize(IMinecraftReader reader) {
		Slot = reader.ReadSByte();
	}
}