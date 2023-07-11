// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSetCooldown : IPacket {

    public byte PacketId => 0x17;

    public int ItemID { get; private set; }
    public int CooldownTicks { get; private set; }

	public PlayClientSetCooldown(
		int itemID,
		int cooldownTicks
		) {
		ItemID = itemID;
		CooldownTicks = cooldownTicks;
	}

	public void Serialize(IMinecraftReader reader) {
		ItemID = reader.ReadVarInt();
        CooldownTicks = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ItemID);
        writer.WriteVarInt(CooldownTicks);
	}
}
