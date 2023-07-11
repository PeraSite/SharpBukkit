using SharpBukkit.Network.API.Stream;

namespace SharpBukkit.Network.API.Serialization;

public interface ISerializable {
	void Serialize(IMinecraftReader reader);

	void Deserialize(IMinecraftWriter writer);
}
