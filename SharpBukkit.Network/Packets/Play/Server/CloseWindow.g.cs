// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerCloseWindow : IPacket {

    public byte PacketId => 0x09;

    public byte WindowId { get; private set; }

	public PlayServerCloseWindow(
		byte windowId
		) {
		WindowId = windowId;
	}

	public void Serialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
	}
}
