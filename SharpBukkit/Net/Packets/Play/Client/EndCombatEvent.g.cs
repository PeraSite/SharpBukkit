// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEndCombatEvent : IPacket {

    public byte PacketId => 0x33;

    public int Duration { get; private set; }
    public int EntityId { get; private set; }

    public PlayClientEndCombatEvent(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEndCombatEvent(
		int duration,
		int entityId
		) {
		Duration = duration;
		EntityId = entityId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Duration);
        writer.WriteInt(EntityId);
	}

	public void Deserialize(IMinecraftReader reader) {
		Duration = reader.ReadVarInt();
        EntityId = reader.ReadInt();
	}
}
