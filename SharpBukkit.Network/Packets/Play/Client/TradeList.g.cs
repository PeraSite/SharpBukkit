// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientTradeList : IPacket {

    public byte PacketId => 0x28;

    public int WindowId { get; private set; }
    public int VillagerLevel { get; private set; }
    public int Experience { get; private set; }
    public bool IsRegularVillager { get; private set; }
    public bool CanRestock { get; private set; }

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

	public void Serialize(IMinecraftReader reader) {
		WindowId = reader.ReadVarInt();
        VillagerLevel = reader.ReadVarInt();
        Experience = reader.ReadVarInt();
        IsRegularVillager = reader.ReadBool();
        CanRestock = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WindowId);
        writer.WriteVarInt(VillagerLevel);
        writer.WriteVarInt(Experience);
        writer.WriteBool(IsRegularVillager);
        writer.WriteBool(CanRestock);
	}
}
