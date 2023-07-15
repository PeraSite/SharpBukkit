using SharpBukkit.Network.API.Stream;

namespace SharpBukkit.Network.API.Serialization;

public interface ISerializable {
	void Serialize(IMinecraftWriter writer);

	void Deserialize(IMinecraftReader reader);
}
