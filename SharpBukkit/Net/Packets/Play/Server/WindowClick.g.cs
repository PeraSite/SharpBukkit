// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerWindowClick : IPacket {

    public byte PacketId => 0x08;

    public byte WindowId { get; private set; }
    public int StateId { get; private set; }
    public short Slot { get; private set; }
    public sbyte MouseButton { get; private set; }
    public int Mode { get; private set; }
    public SlotData CursorItem { get; private set; }

    public PlayServerWindowClick(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerWindowClick(
		byte windowId,
		int stateId,
		short slot,
		sbyte mouseButton,
		int mode,
		SlotData cursorItem
		) {
		WindowId = windowId;
		StateId = stateId;
		Slot = slot;
		MouseButton = mouseButton;
		Mode = mode;
		CursorItem = cursorItem;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteVarInt(StateId);
        writer.WriteShort(Slot);
        writer.WriteSByte(MouseButton);
        writer.WriteVarInt(Mode);
        writer.WriteSlot(CursorItem);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        StateId = reader.ReadVarInt();
        Slot = reader.ReadShort();
        MouseButton = reader.ReadSByte();
        Mode = reader.ReadVarInt();
        CursorItem = reader.ReadSlot();
	}
}
