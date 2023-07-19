// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityMetadata : IPacket {

    public byte PacketId => 0x4d;

    public int EntityId { get; private set; }
    public byte[] Metadata { get; private set; }

    public PlayClientEntityMetadata(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityMetadata(
		int entityId,
		byte[] metadata
		) {
		EntityId = entityId;
		Metadata = metadata;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteMetadata(Metadata);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Metadata = reader.ReadMetadata();
	}
}
