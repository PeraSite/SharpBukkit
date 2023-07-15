using SharpBukkit.Network.API.Serialization;

namespace SharpBukkit.Network.API;

public interface IPacket : IMinecraftSerializable {
	public byte PacketId { get; }
}
