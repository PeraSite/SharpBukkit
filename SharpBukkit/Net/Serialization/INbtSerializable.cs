using SharpNBT;

namespace SharpBukkit.Net.Serialization;

public interface INbtSerializable {
	CompoundTag Serialize();

	void Deserialize(CompoundTag tag);
}
