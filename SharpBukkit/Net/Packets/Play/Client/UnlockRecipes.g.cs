// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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
    public string[] Recipes1 { get; private set; }

    public PlayClientUnlockRecipes(IMinecraftReader reader) {
	    Deserialize(reader);
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
		bool filteringSmoker,
		string[] recipes1
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
		Recipes1 = recipes1;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Action);
        writer.WriteBool(CraftingBookOpen);
        writer.WriteBool(FilteringCraftable);
        writer.WriteBool(SmeltingBookOpen);
        writer.WriteBool(FilteringSmeltable);
        writer.WriteBool(BlastFurnaceOpen);
        writer.WriteBool(FilteringBlastFurnace);
        writer.WriteBool(SmokerBookOpen);
        writer.WriteBool(FilteringSmoker);
        writer.WriteStringArray(Recipes1);
	}

	public void Deserialize(IMinecraftReader reader) {
		Action = reader.ReadVarInt();
        CraftingBookOpen = reader.ReadBool();
        FilteringCraftable = reader.ReadBool();
        SmeltingBookOpen = reader.ReadBool();
        FilteringSmeltable = reader.ReadBool();
        BlastFurnaceOpen = reader.ReadBool();
        FilteringBlastFurnace = reader.ReadBool();
        SmokerBookOpen = reader.ReadBool();
        FilteringSmoker = reader.ReadBool();
        Recipes1 = reader.ReadStringArray();
	}
}
