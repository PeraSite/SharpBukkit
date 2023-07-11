using System.Numerics;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.API.Serialization;
using SharpNBT;

namespace SharpBukkit.Network.API.Stream;

public interface IMinecraftWriter {
	void WriteString(string text);
	void WriteStringArray(string[] texts);
	void WriteSByte(sbyte value);
	void WriteVarInt(int value);
	void WriteBool(bool value);
	void WriteByte(byte value);
	void WriteShort(short value);
	void WriteSlot(ISlotData value);
	void WriteFloat(float value);
	void WriteUuid(Guid value);
	void WritePosition(Vector3 value);
	void WriteUShort(ushort value);
	void WriteDouble(double value);
	void WriteInt(int value);
	void WriteBuffer(byte[] data);
	void WriteByteArray(byte[] values);
	void WriteByteArrays(byte[][] values);
	void WriteLong(long value);
	void WriteLongArray(long[] values);
	void WriteOptNbtTag(CompoundTag? tag);
	void WriteNbtTag(CompoundTag tag);
	void WriteNbt<T>(T data) where T : INbtSerializable;
	void WriteMetadata(byte[] data);
	void WriteSerializable(ISerializable value);
	void WriteSerializableArray<T>(T[] entities) where T : ISerializable, new();
	void Write(byte[] data);
}
