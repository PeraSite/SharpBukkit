using System.Numerics;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.API.Serialization;
using SharpNBT;

namespace SharpBukkit.Network.API.Stream;

public interface IMinecraftReader {
	string ReadString();
	string[] ReadStringArray();
	sbyte ReadSByte();
	int ReadVarInt();
	bool ReadBool();
	byte ReadByte();
	short ReadShort();
	ISlotData ReadSlot();
	float ReadFloat();
	Guid ReadUuid();
	Vector3 ReadPosition();
	ushort ReadUShort();
	uint ReadUInt();
	int ReadInt();
	double ReadDouble();
	byte[] ReadBuffer();
	byte[] ReadByteArray();
	byte[][] ReadByteArrays();
	long ReadLong();
	long[] ReadLongArray();
	byte[] ReadMetadata();
	CompoundTag? ReadOptNbtTag();
	CompoundTag ReadNbtTag();
	T ReadNbt<T>() where T : INbtSerializable, new();
	T ReadSerializable<T>() where T : ISerializable, new();
	T[] ReadSerializableArray<T>() where T : ISerializable, new();
	byte[] Read(int length);
}
