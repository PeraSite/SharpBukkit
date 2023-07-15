// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerDisplayedRecipe : IPacket {

    public byte PacketId => 0x1f;

    public string RecipeId { get; private set; }

    public PlayServerDisplayedRecipe(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerDisplayedRecipe(
		string recipeId
		) {
		RecipeId = recipeId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(RecipeId);
	}

	public void Deserialize(IMinecraftReader reader) {
		RecipeId = reader.ReadString();
	}
}