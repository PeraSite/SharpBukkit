// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientOpenWindow : IPacket {

    public byte PacketId => 0x2e;

    public int WindowId { get; private set; }
    public int InventoryType { get; private set; }
    public string WindowTitle { get; private set; }

    public PlayClientOpenWindow(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientOpenWindow(
		int windowId,
		int inventoryType,
		string windowTitle
		) {
		WindowId = windowId;
		InventoryType = inventoryType;
		WindowTitle = windowTitle;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WindowId);
        writer.WriteVarInt(InventoryType);
        writer.WriteString(WindowTitle);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadVarInt();
        InventoryType = reader.ReadVarInt();
        WindowTitle = reader.ReadString();
	}
}