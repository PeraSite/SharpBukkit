// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteVarInt(NbSlots);
        writer.WriteInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        NbSlots = reader.ReadVarInt();
        EntityId = reader.ReadInt();
	}
}
