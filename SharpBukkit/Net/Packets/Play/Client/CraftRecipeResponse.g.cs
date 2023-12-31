// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientCraftRecipeResponse : IPacket {

    public byte PacketId => 0x31;

    public sbyte WindowId { get; private set; }
    public string Recipe { get; private set; }

    public PlayClientCraftRecipeResponse(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientCraftRecipeResponse(
		sbyte windowId,
		string recipe
		) {
		WindowId = windowId;
		Recipe = recipe;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(WindowId);
        writer.WriteString(Recipe);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadSByte();
        Recipe = reader.ReadString();
	}
}
