// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientMapChunk : IPacket {

    public byte PacketId => 0x22;

    public int X { get; private set; }
    public int Z { get; private set; }
    public Heightmaps Heightmaps { get; private set; }
    public byte[] ChunkData { get; private set; }
    public bool TrustEdges { get; private set; }

    public PlayClientMapChunk(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientMapChunk(
		int x,
		int z,
		Heightmaps heightmaps,
		byte[] chunkData,
		bool trustEdges
		) {
		X = x;
		Z = z;
		Heightmaps = heightmaps;
		ChunkData = chunkData;
		TrustEdges = trustEdges;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(X);
        writer.WriteInt(Z);
        writer.WriteNbt<Heightmaps>(Heightmaps);
        writer.WriteByteArray(ChunkData);
        writer.WriteBool(TrustEdges);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadInt();
        Z = reader.ReadInt();
        Heightmaps = reader.ReadNbt<Heightmaps>();
        ChunkData = reader.ReadByteArray();
        TrustEdges = reader.ReadBool();
	}
}
