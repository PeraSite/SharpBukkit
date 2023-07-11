// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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

	public void Deserialize(IMinecraftReader reader) {
		ChunkX = reader.ReadInt();
        ChunkZ = reader.ReadInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(ChunkX);
        writer.WriteInt(ChunkZ);
	}
}
