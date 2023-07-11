// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerDisplayedRecipe : IPacket {

    public byte PacketId => 0x1f;

    public string RecipeId { get; private set; }

	public PlayServerDisplayedRecipe(
		string recipeId
		) {
		RecipeId = recipeId;
	}

	public void Serialize(IMinecraftReader reader) {
		RecipeId = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(RecipeId);
	}
}
