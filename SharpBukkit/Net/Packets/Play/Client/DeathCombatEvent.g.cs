// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientDeathCombatEvent : IPacket {

    public byte PacketId => 0x35;

    public int PlayerId { get; private set; }
    public int EntityId { get; private set; }
    public string Message { get; private set; }

    public PlayClientDeathCombatEvent(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientDeathCombatEvent(
		int playerId,
		int entityId,
		string message
		) {
		PlayerId = playerId;
		EntityId = entityId;
		Message = message;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(PlayerId);
        writer.WriteInt(EntityId);
        writer.WriteString(Message);
	}

	public void Deserialize(IMinecraftReader reader) {
		PlayerId = reader.ReadVarInt();
        EntityId = reader.ReadInt();
        Message = reader.ReadString();
	}
}
