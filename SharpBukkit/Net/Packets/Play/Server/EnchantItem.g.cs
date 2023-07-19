// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerEnchantItem : IPacket {

    public byte PacketId => 0x07;

    public sbyte WindowId { get; private set; }
    public sbyte Enchantment { get; private set; }

    public PlayServerEnchantItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerEnchantItem(
		sbyte windowId,
		sbyte enchantment
		) {
		WindowId = windowId;
		Enchantment = enchantment;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteSByte(Enchantment);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        Enchantment = reader.ReadSByte();
	}
}
