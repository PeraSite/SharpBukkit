// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerEntityAction : IPacket {

    public byte PacketId => 0x1b;

    public int EntityId { get; private set; }
    public int ActionId { get; private set; }
    public int JumpBoost { get; private set; }

    public PlayServerEntityAction(IMinecraftReader reader) {
	    Deserialize(reader);
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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteVarInt(ActionId);
        writer.WriteVarInt(JumpBoost);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        ActionId = reader.ReadVarInt();
        JumpBoost = reader.ReadVarInt();
	}
}
