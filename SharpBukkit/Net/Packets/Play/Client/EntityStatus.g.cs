// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityStatus : IPacket {

    public byte PacketId => 0x1b;

    public int EntityId { get; private set; }
    public sbyte EntityStatus { get; private set; }

    public PlayClientEntityStatus(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityStatus(
		int entityId,
		sbyte entityStatus
		) {
		EntityId = entityId;
		EntityStatus = entityStatus;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(EntityId);
        writer.WriteSByte(EntityStatus);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadInt();
        EntityStatus = reader.ReadSByte();
	}
}
