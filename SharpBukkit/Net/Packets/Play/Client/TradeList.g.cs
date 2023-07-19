// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientTradeList : IPacket {

    public byte PacketId => 0x28;

    public int WindowId { get; private set; }
    public int VillagerLevel { get; private set; }
    public int Experience { get; private set; }
    public bool IsRegularVillager { get; private set; }
    public bool CanRestock { get; private set; }

    public PlayClientTradeList(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientTradeList(
		int windowId,
		int villagerLevel,
		int experience,
		bool isRegularVillager,
		bool canRestock
		) {
		WindowId = windowId;
		VillagerLevel = villagerLevel;
		Experience = experience;
		IsRegularVillager = isRegularVillager;
		CanRestock = canRestock;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WindowId);
        writer.WriteVarInt(VillagerLevel);
        writer.WriteVarInt(Experience);
        writer.WriteBool(IsRegularVillager);
        writer.WriteBool(CanRestock);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadVarInt();
        VillagerLevel = reader.ReadVarInt();
        Experience = reader.ReadVarInt();
        IsRegularVillager = reader.ReadBool();
        CanRestock = reader.ReadBool();
	}
}
