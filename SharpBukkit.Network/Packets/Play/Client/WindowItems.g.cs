// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWindowItems : IPacket {

    public byte PacketId => 0x14;

    public byte WindowId { get; private set; }
    public int StateId { get; private set; }
    public ISlotData CarriedItem { get; private set; }

    public PlayClientWindowItems(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWindowItems(
		byte windowId,
		int stateId,
		ISlotData carriedItem
		) {
		WindowId = windowId;
		StateId = stateId;
		CarriedItem = carriedItem;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteVarInt(StateId);
        writer.WriteSlot(CarriedItem);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        StateId = reader.ReadVarInt();
        CarriedItem = reader.ReadSlot();
	}
}