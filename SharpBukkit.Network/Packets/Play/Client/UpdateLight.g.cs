// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUpdateLight : IPacket {

    public byte PacketId => 0x25;

    public int ChunkX { get; private set; }
    public int ChunkZ { get; private set; }
    public bool TrustEdges { get; private set; }

	public PlayClientUpdateLight(
		int chunkX,
		int chunkZ,
		bool trustEdges
		) {
		ChunkX = chunkX;
		ChunkZ = chunkZ;
		TrustEdges = trustEdges;
	}

	public void Serialize(IMinecraftReader reader) {
		ChunkX = reader.ReadVarInt();
        ChunkZ = reader.ReadVarInt();
        TrustEdges = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ChunkX);
        writer.WriteVarInt(ChunkZ);
        writer.WriteBool(TrustEdges);
	}
}