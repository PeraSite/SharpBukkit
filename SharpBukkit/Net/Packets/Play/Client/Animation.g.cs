// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientAnimation : IPacket {

    public byte PacketId => 0x06;

    public int EntityId { get; private set; }
    public byte Animation { get; private set; }

    public PlayClientAnimation(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAnimation(
		int entityId,
		byte animation
		) {
		EntityId = entityId;
		Animation = animation;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteByte(Animation);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Animation = reader.ReadByte();
	}
}
