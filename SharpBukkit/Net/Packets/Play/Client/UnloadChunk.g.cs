// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientUnloadChunk : IPacket {

    public byte PacketId => 0x1d;

    public int ChunkX { get; private set; }
    public int ChunkZ { get; private set; }

    public PlayClientUnloadChunk(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUnloadChunk(
		int chunkX,
		int chunkZ
		) {
		ChunkX = chunkX;
		ChunkZ = chunkZ;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(ChunkX);
        writer.WriteInt(ChunkZ);
	}

	public void Deserialize(IMinecraftReader reader) {
		ChunkX = reader.ReadInt();
        ChunkZ = reader.ReadInt();
	}
}
