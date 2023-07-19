using SharpBukkit.Net.Serialization;

namespace SharpBukkit.Net;

public interface IPacket : IMinecraftSerializable {
	public byte PacketId { get; }
}
