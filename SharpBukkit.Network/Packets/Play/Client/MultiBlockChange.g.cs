// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientMultiBlockChange : IPacket {

    public byte PacketId => 0x3f;

    public bool NotTrustEdges { get; private set; }

    public PlayClientMultiBlockChange(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientMultiBlockChange(
		bool notTrustEdges
		) {
		NotTrustEdges = notTrustEdges;
	}

	public void Serialize(IMinecraftReader reader) {
		NotTrustEdges = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteBool(NotTrustEdges);
	}
}