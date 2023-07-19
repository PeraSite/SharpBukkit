// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityHeadRotation : IPacket {

    public byte PacketId => 0x3e;

    public int EntityId { get; private set; }
    public sbyte HeadYaw { get; private set; }

    public PlayClientEntityHeadRotation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityHeadRotation(
		int entityId,
		sbyte headYaw
		) {
		EntityId = entityId;
		HeadYaw = headYaw;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteSByte(HeadYaw);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        HeadYaw = reader.ReadSByte();
	}
}
