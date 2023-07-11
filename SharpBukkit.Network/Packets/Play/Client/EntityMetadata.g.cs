// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityMetadata : IPacket {

    public byte PacketId => 0x4d;

    public int EntityId { get; private set; }
    public byte[] Metadata { get; private set; }

	public PlayClientEntityMetadata(
		int entityId,
		byte[] metadata
		) {
		EntityId = entityId;
		Metadata = metadata;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Metadata = reader.ReadMetadata();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteMetadata(Metadata);
	}
}
