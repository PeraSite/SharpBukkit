// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientCraftProgressBar : IPacket {

    public byte PacketId => 0x15;

    public byte WindowId { get; private set; }
    public short Property { get; private set; }
    public short Value { get; private set; }

    public PlayClientCraftProgressBar(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientCraftProgressBar(
		byte windowId,
		short property,
		short value
		) {
		WindowId = windowId;
		Property = property;
		Value = value;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteShort(Property);
        writer.WriteShort(Value);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        Property = reader.ReadShort();
        Value = reader.ReadShort();
	}
}
