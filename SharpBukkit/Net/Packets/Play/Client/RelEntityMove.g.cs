// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientRelEntityMove : IPacket {

    public byte PacketId => 0x29;

    public int EntityId { get; private set; }
    public short DX { get; private set; }
    public short DY { get; private set; }
    public short DZ { get; private set; }
    public bool OnGround { get; private set; }

    public PlayClientRelEntityMove(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientRelEntityMove(
		int entityId,
		short dX,
		short dY,
		short dZ,
		bool onGround
		) {
		EntityId = entityId;
		DX = dX;
		DY = dY;
		DZ = dZ;
		OnGround = onGround;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteShort(DX);
        writer.WriteShort(DY);
        writer.WriteShort(DZ);
        writer.WriteBool(OnGround);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        DX = reader.ReadShort();
        DY = reader.ReadShort();
        DZ = reader.ReadShort();
        OnGround = reader.ReadBool();
	}
}
