// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCloseWindow : IPacket {

    public byte PacketId => 0x13;

    public byte WindowId { get; private set; }

	public PlayClientCloseWindow(
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