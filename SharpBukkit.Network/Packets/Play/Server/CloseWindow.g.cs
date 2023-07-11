// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerCloseWindow : IPacket {

    public byte PacketId => 0x09;

    public byte WindowId { get; private set; }

    public PlayServerCloseWindow(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerCloseWindow(
		byte windowId
		) {
		WindowId = windowId;
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
	}
}
