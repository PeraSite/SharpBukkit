// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerRecipeBook : IPacket {

    public byte PacketId => 0x1e;

    public int BookId { get; private set; }
    public bool BookOpen { get; private set; }
    public bool FilterActive { get; private set; }

	public PlayServerRecipeBook(
		int bookId,
		bool bookOpen,
		bool filterActive
		) {
		BookId = bookId;
		BookOpen = bookOpen;
		FilterActive = filterActive;
	}

	public void Serialize(IMinecraftReader reader) {
		BookId = reader.ReadVarInt();
        BookOpen = reader.ReadBool();
        FilterActive = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(BookId);
        writer.WriteBool(BookOpen);
        writer.WriteBool(FilterActive);
	}
}