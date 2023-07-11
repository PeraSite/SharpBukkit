// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientDeathCombatEvent : IPacket {

    public byte PacketId => 0x35;

    public int PlayerId { get; private set; }
    public int EntityId { get; private set; }
    public string Message { get; private set; }

	public PlayClientDeathCombatEvent(
		int playerId,
		int entityId,
		string message
		) {
		PlayerId = playerId;
		EntityId = entityId;
		Message = message;
	}

	public void Serialize(IMinecraftReader reader) {
		PlayerId = reader.ReadVarInt();
        EntityId = reader.ReadInt();
        Message = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(PlayerId);
        writer.WriteInt(EntityId);
        writer.WriteString(Message);
	}
}
