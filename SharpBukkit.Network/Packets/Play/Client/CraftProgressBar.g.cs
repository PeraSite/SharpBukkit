// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCraftProgressBar : IPacket {

    public byte PacketId => 0x15;

    public byte WindowId { get; private set; }
    public short Property { get; private set; }
    public short Value { get; private set; }

	public PlayClientCraftProgressBar(
		byte windowId,
		short property,
		short value
		) {
		WindowId = windowId;
		Property = property;
		Value = value;
	}

	public void Serialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
        Property = reader.ReadShort();
        Value = reader.ReadShort();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
        writer.WriteShort(Property);
        writer.WriteShort(Value);
	}
}
