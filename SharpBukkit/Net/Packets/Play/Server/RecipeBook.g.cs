// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerRecipeBook : IPacket {

    public byte PacketId => 0x1e;

    public int BookId { get; private set; }
    public bool BookOpen { get; private set; }
    public bool FilterActive { get; private set; }

    public PlayServerRecipeBook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerRecipeBook(
		int bookId,
		bool bookOpen,
		bool filterActive
		) {
		BookId = bookId;
		BookOpen = bookOpen;
		FilterActive = filterActive;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(BookId);
        writer.WriteBool(BookOpen);
        writer.WriteBool(FilterActive);
	}

	public void Deserialize(IMinecraftReader reader) {
		BookId = reader.ReadVarInt();
        BookOpen = reader.ReadBool();
        FilterActive = reader.ReadBool();
	}
}
