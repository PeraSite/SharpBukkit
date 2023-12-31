// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientBlockBreakAnimation : IPacket {

    public byte PacketId => 0x09;

    public int EntityId { get; private set; }
    public Vector3 Location { get; private set; }
    public sbyte DestroyStage { get; private set; }

    public PlayClientBlockBreakAnimation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientBlockBreakAnimation(
		int entityId,
		Vector3 location,
		sbyte destroyStage
		) {
		EntityId = entityId;
		Location = location;
		DestroyStage = destroyStage;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WritePosition(Location);
        writer.WriteSByte(DestroyStage);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Location = reader.ReadPosition();
        DestroyStage = reader.ReadSByte();
	}
}
