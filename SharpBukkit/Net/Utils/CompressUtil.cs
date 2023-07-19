using System.IO;
using Ionic.Zlib;

namespace SharpBukkit.Net.Utils;

public static class CompressUtil {
	public static byte[] CompressData(byte[] inData) {
		using var outMemoryStream = new MemoryStream();
		using (var outZStream = new ZlibStream(outMemoryStream, CompressionMode.Compress, CompressionLevel.Default, true)) {
			outZStream.Write(inData, 0, inData.Length);
		}
		return outMemoryStream.ToArray();
	}

	public static byte[] DecompressData(byte[] inData) {
		using var outMemoryStream = new MemoryStream();
		using (var outZStream = new ZlibStream(outMemoryStream, CompressionMode.Decompress, CompressionLevel.Default, true)) {
			outZStream.Write(inData, 0, inData.Length);
		}
		return outMemoryStream.ToArray();
	}
}
