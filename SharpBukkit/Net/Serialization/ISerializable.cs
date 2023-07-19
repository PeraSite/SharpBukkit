namespace SharpBukkit.Net.Serialization;

public interface ISerializable<in TWriter, in TReader> {
	void Serialize(TWriter writer);

	void Deserialize(TReader reader);
}
