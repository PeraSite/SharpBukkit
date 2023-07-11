using SharpBukkit.Network.API.Serialization;

namespace SharpBukkit.Network.API;

public interface IPacket : ISerializable {
	public byte PacketId { get; }
}
