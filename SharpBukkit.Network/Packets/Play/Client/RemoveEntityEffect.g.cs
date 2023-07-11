// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientRemoveEntityEffect : IPacket {

    public byte PacketId => 0x3b;

    public int EntityId { get; private set; }
    public int EffectId { get; private set; }

	public PlayClientRemoveEntityEffect(
		int entityId,
		int effectId
		) {
		EntityId = entityId;
		EffectId = effectId;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        EffectId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteVarInt(EffectId);
	}
}
