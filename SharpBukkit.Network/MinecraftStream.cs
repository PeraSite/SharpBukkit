using System.Net;
using System.Numerics;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.API.Serialization;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.Extensions;
using SharpBukkit.Network.Models.Inventory;
using SharpNBT;

namespace SharpBukkit.Network {
	public class MinecraftStream : Stream, IMinecraftStream {
		private const FormatOptions FORMAT_OPTION = FormatOptions.Java;


		private Stream _baseStream;
		private BufferedBlockCipher? _encryptCipher;
		private BufferedBlockCipher? _decryptCipher;
		private readonly CancellationTokenSource _cancellationTokenSource;

		public MinecraftStream(Stream baseStream) {
			_baseStream = baseStream;
			_cancellationTokenSource = new CancellationTokenSource();
		}

		public void InitEncryption(byte[] key) {
			const int bitBlockSize = 8;
			const int ivLength = 16;

			_encryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), bitBlockSize));
			_encryptCipher.Init(true, new ParametersWithIV(new KeyParameter(key), key, 0, ivLength));

			_decryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), bitBlockSize));
			_decryptCipher.Init(false, new ParametersWithIV(new KeyParameter(key), key, 0, ivLength));

			_baseStream = new CipherStream(_baseStream, _decryptCipher, _encryptCipher);
		}

		#region Stream
		public override bool CanRead => _baseStream.CanRead;
		public override bool CanSeek => _baseStream.CanRead;
		public override bool CanWrite => _baseStream.CanRead;
		public override long Length => _baseStream.Length;

		public override long Position {
			get => _baseStream.Position;
			set => _baseStream.Position = value;
		}

		public override long Seek(long offset, SeekOrigin origin) {
			return _baseStream.Seek(offset, origin);
		}

		public override void SetLength(long value) {
			_baseStream.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count) {
			return _baseStream.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count) {
			_baseStream.Write(buffer, offset, count);
		}

		public override void Flush() {
			_baseStream.Flush();
		}
		  #endregion

		#region Reader
		public CompoundTag ReadNbtTag() {
			var tag = _baseStream.ReadCompoundTag(FORMAT_OPTION);

			if (tag == null) {
				throw new InvalidDataException($"Expected a compound tag, but got: {tag}");
			}

			return tag;
		}

		public CompoundTag? ReadOptNbtTag() {
			return _baseStream.ReadCompoundTag(FORMAT_OPTION);
		}

		public T ReadNbt<T>() where T : INbtSerializable, new() {
			var tag = ReadNbtTag();
			var obj = tag.ToObject<T>();
			return obj;
		}

		public T ReadSerializable<T>() where T : IMinecraftSerializable, new() {
			var bits = new T();
			bits.Serialize(this);
			return bits;
		}

		public byte[] Read(int length) {
			var s = new SpinWait();
			var read = 0;

			var buffer = new byte[length];
			while (read < buffer.Length &&
			       !_cancellationTokenSource.IsCancellationRequested &&
			       s.Count < 25)
				// Give the network some time to catch up on sending data,
				// but really 25 cycles should be enough.
			{
				var oldRead = read;

				var r = Read(buffer, read, length - read);
				if (r < 0) //No data read?
				{
					break;
				}

				read += r;

				if (read == oldRead) {
					s.SpinOnce();
				}
				if (_cancellationTokenSource.IsCancellationRequested)
					throw new ObjectDisposedException("");
			}

			return buffer;
		}

		public override int ReadByte() {
			return _baseStream.ReadByte();
		}

		public int ReadInt() {
			var dat = Read(4);
			var value = BitConverter.ToInt32(dat, 0);
			return IPAddress.NetworkToHostOrder(value);
		}

		public ISlotData ReadSlot() {
			var slot = new SlotData();
			slot.Deserialize(this);
			return slot;
		}

		public float ReadFloat() {
			var almost = Read(4);
			var f = BitConverter.ToSingle(almost, 0);
			return NetworkToHostOrder(f);
		}

		public bool ReadBool() {
			var answer = ReadByte();
			if (answer == 1)
				return true;
			return false;
		}

		byte IMinecraftReader.ReadByte() {
			return (byte)ReadByte();
		}

		public double ReadDouble() {
			var almostValue = Read(8);
			return NetworkToHostOrder(almostValue);
		}

		public byte[] ReadBuffer() {
			var length = ReadVarInt(out _);
			var array = new byte[length + 1];
			array[0] = (byte)length;
			_ = Read(array, 1, length);
			return array;
		}

		public string[] ReadStringArray() {
			var length = ReadVarInt(out _);
			var result = new string[length];
			for (var i = 0; i < length; i++) {
				result[i] = ReadString();
			}
			return result;
		}

		public T[] ReadSerializableArray<T>() where T : IMinecraftSerializable, new() {
			var length = ReadVarInt(out _);
			var result = new T[length];
			for (var i = 0; i < length; i++) {
				result[i] = ReadSerializable<T>();
			}
			return result;
		}

		public long[] ReadLongArray() {
			var length = ReadVarInt(out _);
			var result = new long[length];
			for (var i = 0; i < length; i++) {
				result[i] = ReadLong();
			}
			return result;
		}

		public byte[] ReadByteArray() {
			var length = ReadVarInt(out _);
			var result = new byte[length];
			for (var i = 0; i < length; i++) {
				result[i] = (byte)ReadByte();
			}
			return result;
		}

		public byte[][] ReadByteArrays() {
			var length = ReadVarInt(out _);
			var result = new byte[length][];
			for (var i = 0; i < length; i++) {
				result[i] = ReadByteArray();
			}
			return result;
		}

		public sbyte ReadSByte() {
			return (sbyte)ReadByte();
		}

		public int ReadVarInt() {
			return ReadVarInt(out _);
		}

		public int ReadVarInt(out int bytesRead) {
			var numRead = 0;
			var result = 0;
			byte read;
			do {
				read = (byte)ReadByte();
				var value = read & 0x7f;
				result |= value << (7 * numRead);
				numRead++;
				if (numRead > 5) {
					throw new Exception("VarInt is too big");
				}
			} while ((read & 0x80) != 0);
			bytesRead = numRead;
			return result;
		}

		public long ReadVarLong() {
			var numRead = 0;
			long result = 0;
			byte read;
			do {
				read = (byte)ReadByte();
				var value = read & 0x7f;
				result |= (uint)(value << (7 * numRead));
				numRead++;
				if (numRead > 10) {
					throw new Exception("VarLong is too big");
				}
			} while ((read & 0x80) != 0);

			return result;
		}

		public short ReadShort() {
			var da = Read(2);
			var d = BitConverter.ToInt16(da, 0);
			return IPAddress.NetworkToHostOrder(d);
		}

		public uint ReadUInt() {
			var da = Read(4);
			return NetworkToHostOrder(BitConverter.ToUInt32(da, 0));
		}

		public ushort ReadUShort() {
			var da = Read(2);
			return NetworkToHostOrder(BitConverter.ToUInt16(da, 0));
		}

		public ushort[] ReadUShort(int count) {
			var us = new ushort[count];
			for (var i = 0; i < us.Length; i++) {
				var da = Read(2);
				var d = BitConverter.ToUInt16(da, 0);
				us[i] = d;
			}
			return NetworkToHostOrder(us);
		}

		public ushort[] ReadUShortLocal(int count) {
			var us = new ushort[count];
			for (var i = 0; i < us.Length; i++) {
				var da = Read(2);
				var d = BitConverter.ToUInt16(da, 0);
				us[i] = d;
			}
			return us;
		}

		public short[] ReadShortLocal(int count) {
			var us = new short[count];
			for (var i = 0; i < us.Length; i++) {
				var da = Read(2);
				var d = BitConverter.ToInt16(da, 0);
				us[i] = d;
			}
			return us;
		}

		public string ReadString() {
			var length = ReadVarInt();
			var stringValue = Read(length);

			return Encoding.UTF8.GetString(stringValue);
		}

		public long ReadLong() {
			var l = Read(8);
			return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(l, 0));
		}

		public byte[] ReadMetadata() {
			throw new NotImplementedException();
		}

		public ulong ReadULong() {
			var l = Read(8);
			return NetworkToHostOrder(BitConverter.ToUInt64(l, 0));
		}

		public Vector3 ReadPosition() {
			var val = ReadLong();
			var x = Convert.ToSingle(val >> 38);
			var y = Convert.ToSingle(val & 0xFFF);
			var z = Convert.ToSingle(val << 38 >> 38 >> 12);
			return new Vector3(x, y, z);
		}

		private double NetworkToHostOrder(byte[] data) {
			if (BitConverter.IsLittleEndian) {
				Array.Reverse(data);
			}
			return BitConverter.ToDouble(data, 0);
		}

		private float NetworkToHostOrder(float network) {
			var bytes = BitConverter.GetBytes(network);

			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);

			return BitConverter.ToSingle(bytes, 0);
		}

		private ushort[] NetworkToHostOrder(ushort[] network) {
			if (BitConverter.IsLittleEndian)
				Array.Reverse(network);
			return network;
		}

		private ushort NetworkToHostOrder(ushort network) {
			var net = BitConverter.GetBytes(network);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(net);
			return BitConverter.ToUInt16(net, 0);
		}

		private uint NetworkToHostOrder(uint network) {
			var net = BitConverter.GetBytes(network);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(net);
			return BitConverter.ToUInt32(net, 0);
		}

		private ulong NetworkToHostOrder(ulong network) {
			var net = BitConverter.GetBytes(network);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(net);
			return BitConverter.ToUInt64(net, 0);
		}
		#endregion

		#region Writer
		public void WriteNbt<T>(T data) where T : INbtSerializable {
			CompoundTag tag = data.Serialize();
			WriteNbtTag(tag);
		}

		public void WriteOptNbtTag(CompoundTag? tag) {
			if (tag == null) {
				WriteByte(0);
				return;
			}
			WriteNbtTag(tag);
		}

		public void WriteNbtTag(CompoundTag tag) {
			_baseStream.WriteCompoundTag(tag, FORMAT_OPTION);
		}

		public void WriteNbt(INbtSerializable data) {
			var tag = data.Serialize();
			WriteNbtTag(tag);
		}

		public void WriteMetadata(byte[] data) {
			throw new NotImplementedException();
		}

		public void WriteSerializable(IMinecraftSerializable value) {
			value.Serialize(this);
		}

		public void Write(byte[] data) {
			Write(data, 0, data.Length);
		}

		public void WritePosition(Vector3 position) {
			var x = Convert.ToInt64(position.X);
			var y = Convert.ToInt64(position.Y);
			var z = Convert.ToInt64(position.Z);
			var toSend = ((x & 0x3FFFFFF) << 38) | ((z & 0x3FFFFFF) << 12) | (y & 0xFFF);
			WriteLong(toSend);
		}

		public void WriteStringArray(string[] texts) {
			if (texts.Length == 0) {
				WriteVarInt(0);
				return;
			}
			WriteVarInt(texts.Length);
			foreach (var text in texts)
				WriteString(text);
		}

		public void WriteSerializableArray<T>(T[] values) where T : IMinecraftSerializable, new() {
			if (values.Length == 0) {
				WriteVarInt(0);
				return;
			}
			WriteVarInt(values.Length);
			foreach (var value in values)
				WriteSerializable(value);
		}

		public void WriteLongArray(long[] values) {
			if (values.Length == 0) {
				WriteVarInt(0);
				return;
			}
			WriteVarInt(values.Length);
			foreach (var value in values)
				WriteLong(value);
		}

		public void WriteByteArray(byte[] values) {
			if (values.Length == 0) {
				WriteVarInt(0);
				return;
			}
			WriteVarInt(values.Length);
			foreach (var value in values)
				WriteByte(value);
		}

		public void WriteByteArrays(byte[][] values) {
			if (values.Length == 0) {
				WriteVarInt(0);
				return;
			}
			WriteVarInt(values.Length);
			foreach (var value in values)
				WriteByteArray(value);
		}

		public void WriteSByte(sbyte value) {
			WriteByte((byte)value);
		}

		void IMinecraftWriter.WriteVarInt(int value) {
			WriteVarInt(value);
		}

		public int WriteVarInt(int value) {
			var write = 0;
			do {
				var temp = (byte)(value & 127);
				value >>= 7;
				if (value != 0) {
					temp |= 128;
				}
				WriteByte(temp);
				write++;
			} while (value != 0);
			return write;
		}

		public int WriteVarLong(long value) {
			var write = 0;
			do {
				var temp = (byte)(value & 127);
				value >>= 7;
				if (value != 0) {
					temp |= 128;
				}
				WriteByte(temp);
				write++;
			} while (value != 0);
			return write;
		}

		public void WriteInt(int data) {
			var buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data));
			Write(buffer);
		}

		public void WriteBuffer(byte[] data) {
			Write(data);
		}

		public void WriteString(string data) {
			var stringData = Encoding.UTF8.GetBytes(data);
			WriteVarInt(stringData.Length);
			Write(stringData);
		}

		public void WriteShort(short data) {
			var shortData = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data));
			Write(shortData);
		}

		public void WriteSlot(ISlotData value) {
			value.Serialize(this);
		}

		public void WriteUShort(ushort data) {
			var uShortData = BitConverter.GetBytes(data);
			Write(uShortData);
		}

		public void WriteBool(bool data) {
			Write(BitConverter.GetBytes(data));
		}

		public void WriteDouble(double data) {
			Write(HostToNetworkOrder(data));
		}

		public void WriteFloat(float data) {
			Write(HostToNetworkOrder(data));
		}

		public void WriteLong(long data) {
			Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data)));
		}

		public void WriteULong(ulong data) {
			Write(HostToNetworkOrderLong(data));
		}

		public void WriteUuid(Guid uuid) {
			var guid = uuid.ToByteArray();
			var long1 = new byte[8];
			var long2 = new byte[8];
			Array.Copy(guid, 0, long1, 0, 8);
			Array.Copy(guid, 8, long2, 0, 8);
			Write(long1);
			Write(long2);
		}

		public Guid ReadUuid() {
			var long1 = Read(8);
			var long2 = Read(8);
			return new Guid(long1.Concat(long2).ToArray());
		}

		private byte[] HostToNetworkOrder(double d) {
			var data = BitConverter.GetBytes(d);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(data);
			return data;
		}

		private byte[] HostToNetworkOrder(float host) {
			var bytes = BitConverter.GetBytes(host);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return bytes;
		}

		private byte[] HostToNetworkOrderLong(ulong host) {
			var bytes = BitConverter.GetBytes(host);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return bytes;
		}
        #endregion


		private readonly object _disposeLock = new object();
		private bool _disposed;

		protected override void Dispose(bool disposing) {
			if (!Monitor.IsEntered(_disposeLock))
				return;
			try {
				if (disposing && !_disposed) {
					_disposed = true;
					if (!_cancellationTokenSource.IsCancellationRequested)
						_cancellationTokenSource.Cancel();
				}
				base.Dispose(disposing);
			}
			finally {
				Monitor.Exit(_disposeLock);
			}
		}
	}
}
