// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientMapChunk : IPacket {

    public byte PacketId => 0x22;

    public int X { get; private set; }
    public int Z { get; private set; }
    public Heightmaps Heightmaps { get; private set; }
    public bool TrustEdges { get; private set; }

	public PlayClientMapChunk(
		int x,
		int z,
		Heightmaps heightmaps,
		bool trustEdges
		) {
		X = x;
		Z = z;
		Heightmaps = heightmaps;
		TrustEdges = trustEdges;
	}

	public void Serialize(IMinecraftReader reader) {
		X = reader.ReadInt();
        Z = reader.ReadInt();
        Heightmaps = reader.ReadNbt<Heightmaps>();
        TrustEdges = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(X);
        writer.WriteInt(Z);
        writer.WriteNbt<Heightmaps>(Heightmaps);
        writer.WriteBool(TrustEdges);
	}
}
