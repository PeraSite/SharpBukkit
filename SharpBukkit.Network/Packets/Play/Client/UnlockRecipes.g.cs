// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUnlockRecipes : IPacket {

    public byte PacketId => 0x39;

    public int Action { get; private set; }
    public bool CraftingBookOpen { get; private set; }
    public bool FilteringCraftable { get; private set; }
    public bool SmeltingBookOpen { get; private set; }
    public bool FilteringSmeltable { get; private set; }
    public bool BlastFurnaceOpen { get; private set; }
    public bool FilteringBlastFurnace { get; private set; }
    public bool SmokerBookOpen { get; private set; }
    public bool FilteringSmoker { get; private set; }

    public PlayClientUnlockRecipes(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientUnlockRecipes(
		int action,
		bool craftingBookOpen,
		bool filteringCraftable,
		bool smeltingBookOpen,
		bool filteringSmeltable,
		bool blastFurnaceOpen,
		bool filteringBlastFurnace,
		bool smokerBookOpen,
		bool filteringSmoker
		) {
		Action = action;
		CraftingBookOpen = craftingBookOpen;
		FilteringCraftable = filteringCraftable;
		SmeltingBookOpen = smeltingBookOpen;
		FilteringSmeltable = filteringSmeltable;
		BlastFurnaceOpen = blastFurnaceOpen;
		FilteringBlastFurnace = filteringBlastFurnace;
		SmokerBookOpen = smokerBookOpen;
		FilteringSmoker = filteringSmoker;
	}

	public void Serialize(IMinecraftReader reader) {
		Action = reader.ReadVarInt();
        CraftingBookOpen = reader.ReadBool();
        FilteringCraftable = reader.ReadBool();
        SmeltingBookOpen = reader.ReadBool();
        FilteringSmeltable = reader.ReadBool();
        BlastFurnaceOpen = reader.ReadBool();
        FilteringBlastFurnace = reader.ReadBool();
        SmokerBookOpen = reader.ReadBool();
        FilteringSmoker = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Action);
        writer.WriteBool(CraftingBookOpen);
        writer.WriteBool(FilteringCraftable);
        writer.WriteBool(SmeltingBookOpen);
        writer.WriteBool(FilteringSmeltable);
        writer.WriteBool(BlastFurnaceOpen);
        writer.WriteBool(FilteringBlastFurnace);
        writer.WriteBool(SmokerBookOpen);
        writer.WriteBool(FilteringSmoker);
	}
}