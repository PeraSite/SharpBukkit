// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerEnchantItem : IPacket {

    public byte PacketId => 0x07;

    public sbyte WindowId { get; private set; }
    public sbyte Enchantment { get; private set; }

    public PlayServerEnchantItem(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerEnchantItem(
		sbyte windowId,
		sbyte enchantment
		) {
		WindowId = windowId;
		Enchantment = enchantment;
	}

	public void Serialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        Enchantment = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteSByte(Enchantment);
	}
}