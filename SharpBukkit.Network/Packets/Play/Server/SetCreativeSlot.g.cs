// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSetCreativeSlot : IPacket {

    public byte PacketId => 0x28;

    public short Slot { get; private set; }
    public ISlotData Item { get; private set; }

    public PlayServerSetCreativeSlot(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSetCreativeSlot(
		short slot,
		ISlotData item
		) {
		Slot = slot;
		Item = item;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteShort(Slot);
        writer.WriteSlot(Item);
	}

	public void Deserialize(IMinecraftReader reader) {
		Slot = reader.ReadShort();
        Item = reader.ReadSlot();
	}
}