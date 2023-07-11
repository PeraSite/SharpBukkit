using SharpNBT;

namespace SharpBukkit.Network.API.Serialization;

public interface INbtSerializable {
	CompoundTag Serialize();

	void Deserialize(CompoundTag tag);
}
