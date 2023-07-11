// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientOpenHorseWindow : IPacket {

    public byte PacketId => 0x1f;

    public byte WindowId { get; private set; }
    public int NbSlots { get; private set; }
    public int EntityId { get; private set; }

    public PlayClientOpenHorseWindow(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientOpenHorseWindow(
		byte windowId,
		int nbSlots,
		int entityId
		) {
		WindowId = windowId;
		NbSlots = nbSlots;
		EntityId = entityId;
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        NbSlots = reader.ReadVarInt();
        EntityId = reader.ReadInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteVarInt(NbSlots);
        writer.WriteInt(EntityId);
	}
}
