// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientRemoveEntityEffect : IPacket {

    public byte PacketId => 0x3b;

    public int EntityId { get; private set; }
    public int EffectId { get; private set; }

    public PlayClientRemoveEntityEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientRemoveEntityEffect(
		int entityId,
		int effectId
		) {
		EntityId = entityId;
		EffectId = effectId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteVarInt(EffectId);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        EffectId = reader.ReadVarInt();
	}
}
