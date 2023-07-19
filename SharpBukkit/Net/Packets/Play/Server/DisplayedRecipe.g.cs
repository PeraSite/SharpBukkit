// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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
