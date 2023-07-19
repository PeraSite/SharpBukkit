// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityUpdateAttributes : IPacket {

    public byte PacketId => 0x64;

    public int EntityId { get; private set; }

    public PlayClientEntityUpdateAttributes(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityUpdateAttributes(
		int entityId
		) {
		EntityId = entityId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}
}
