// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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

	public void Deserialize(IMinecraftReader reader) {
		Duration = reader.ReadVarInt();
        EntityId = reader.ReadInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Duration);
        writer.WriteInt(EntityId);
	}
}
