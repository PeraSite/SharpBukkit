// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerCraftRecipeRequest : IPacket {

    public byte PacketId => 0x18;

    public sbyte WindowId { get; private set; }
    public string Recipe { get; private set; }
    public bool MakeAll { get; private set; }

    public PlayServerCraftRecipeRequest(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerCraftRecipeRequest(
		sbyte windowId,
		string recipe,
		bool makeAll
		) {
		WindowId = windowId;
		Recipe = recipe;
		MakeAll = makeAll;
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        Recipe = reader.ReadString();
        MakeAll = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteString(Recipe);
        writer.WriteBool(MakeAll);
	}
}
