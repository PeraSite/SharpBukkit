// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCraftRecipeResponse : IPacket {

    public byte PacketId => 0x31;

    public sbyte WindowId { get; private set; }
    public string Recipe { get; private set; }

	public PlayClientCraftRecipeResponse(
		sbyte windowId,
		string recipe
		) {
		WindowId = windowId;
		Recipe = recipe;
	}

	public void Serialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        Recipe = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteString(Recipe);
	}
}