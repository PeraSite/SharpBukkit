using SharpBukkit.Net.Serialization;

namespace SharpBukkit.Net.Packets;

public interface IPacket : IMinecraftSerializable {
	public byte PacketId { get; }
}
