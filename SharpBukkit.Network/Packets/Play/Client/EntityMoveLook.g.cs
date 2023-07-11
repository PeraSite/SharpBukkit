// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityMoveLook : IPacket {

    public byte PacketId => 0x2a;

    public int EntityId { get; private set; }
    public short DX { get; private set; }
    public short DY { get; private set; }
    public short DZ { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayClientEntityMoveLook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityMoveLook(
		int entityId,
		short dX,
		short dY,
		short dZ,
		sbyte yaw,
		sbyte pitch,
		bool onGround
		) {
		EntityId = entityId;
		DX = dX;
		DY = dY;
		DZ = dZ;
		Yaw = yaw;
		Pitch = pitch;
		OnGround = onGround;
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        DX = reader.ReadShort();
        DY = reader.ReadShort();
        DZ = reader.ReadShort();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
        OnGround = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteShort(DX);
        writer.WriteShort(DY);
        writer.WriteShort(DZ);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
        writer.WriteBool(OnGround);
	}
}
