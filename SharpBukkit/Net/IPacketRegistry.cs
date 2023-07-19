using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;

namespace SharpBukkit.Net;

public interface IPacketRegistry {
	void Load();

	IPacket Create(IMinecraftReader reader, ConnectionState state, byte id);
}
