// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerEntityAction : IPacket {

    public byte PacketId => 0x1b;

    public int EntityId { get; private set; }
    public int ActionId { get; private set; }
    public int JumpBoost { get; private set; }

    public PlayServerEntityAction(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerEntityAction(
		int entityId,
		int actionId,
		int jumpBoost
		) {
		EntityId = entityId;
		ActionId = actionId;
		JumpBoost = jumpBoost;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        ActionId = reader.ReadVarInt();
        JumpBoost = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteVarInt(ActionId);
        writer.WriteVarInt(JumpBoost);
	}
}