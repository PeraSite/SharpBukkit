// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityLook : IPacket {

    public byte PacketId => 0x2b;

    public int EntityId { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayClientEntityLook(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityLook(
		int entityId,
		sbyte yaw,
		sbyte pitch,
		bool onGround
		) {
		EntityId = entityId;
		Yaw = yaw;
		Pitch = pitch;
		OnGround = onGround;
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
        OnGround = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
        writer.WriteBool(OnGround);
	}
}
