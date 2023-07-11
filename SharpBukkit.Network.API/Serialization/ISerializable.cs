using SharpBukkit.Network.API.Stream;

namespace SharpBukkit.Network.API.Serialization;

public interface ISerializable {
	void Deserialize(IMinecraftReader reader);

	void Serialize(IMinecraftWriter writer);
}
