// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerHeldItemSlot : IPacket {

    public byte PacketId => 0x25;

    public short SlotId { get; private set; }

    public PlayServerHeldItemSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerHeldItemSlot(
		short slotId
		) {
		SlotId = slotId;
	}

	public void Deserialize(IMinecraftReader reader) {
		SlotId = reader.ReadShort();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteShort(SlotId);
	}
}
