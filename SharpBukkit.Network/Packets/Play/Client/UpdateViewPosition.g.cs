// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUpdateViewPosition : IPacket {

    public byte PacketId => 0x49;

    public int ChunkX { get; private set; }
    public int ChunkZ { get; private set; }

    public PlayClientUpdateViewPosition(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientUpdateViewPosition(
		int chunkX,
		int chunkZ
		) {
		ChunkX = chunkX;
		ChunkZ = chunkZ;
	}

	public void Serialize(IMinecraftReader reader) {
		ChunkX = reader.ReadVarInt();
        ChunkZ = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ChunkX);
        writer.WriteVarInt(ChunkZ);
	}
}