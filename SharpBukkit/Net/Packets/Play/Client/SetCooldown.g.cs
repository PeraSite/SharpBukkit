// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSetCooldown : IPacket {

    public byte PacketId => 0x17;

    public int ItemID { get; private set; }
    public int CooldownTicks { get; private set; }

    public PlayClientSetCooldown(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetCooldown(
		int itemID,
		int cooldownTicks
		) {
		ItemID = itemID;
		CooldownTicks = cooldownTicks;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ItemID);
        writer.WriteVarInt(CooldownTicks);
	}

	public void Deserialize(IMinecraftReader reader) {
		ItemID = reader.ReadVarInt();
        CooldownTicks = reader.ReadVarInt();
	}
}
