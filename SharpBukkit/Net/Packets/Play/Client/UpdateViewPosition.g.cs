// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientUpdateViewPosition : IPacket {

    public byte PacketId => 0x49;

    public int ChunkX { get; private set; }
    public int ChunkZ { get; private set; }

    public PlayClientUpdateViewPosition(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUpdateViewPosition(
		int chunkX,
		int chunkZ
		) {
		ChunkX = chunkX;
		ChunkZ = chunkZ;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ChunkX);
        writer.WriteVarInt(ChunkZ);
	}

	public void Deserialize(IMinecraftReader reader) {
		ChunkX = reader.ReadVarInt();
        ChunkZ = reader.ReadVarInt();
	}
}
