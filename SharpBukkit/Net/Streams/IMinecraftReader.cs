using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Serialization;
using SharpNBT;

namespace SharpBukkit.Net.Streams;

public interface IMinecraftReader {
	string ReadString();
	string[] ReadStringArray();
	sbyte ReadSByte();
	int ReadVarInt();
	bool ReadBool();
	byte ReadByte();
	short ReadShort();
	SlotData ReadSlot();
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
	T ReadSerializable<T>() where T : IMinecraftSerializable, new();
	T[] ReadSerializableArray<T>() where T : IMinecraftSerializable, new();
	byte[] Read(int length);
}
