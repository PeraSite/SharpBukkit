using SharpBukkit.Network.API.Stream;

namespace SharpBukkit.Network.API;

public interface IPacketRegistry {
	void Load();

	IPacket Create(IMinecraftReader reader, ConnectionState state, byte id);
}
