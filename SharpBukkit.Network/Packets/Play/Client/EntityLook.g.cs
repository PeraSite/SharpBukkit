// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityLook : IPacket {

    public byte PacketId => 0x2b;

    public int EntityId { get; private set; }
    public sbyte Yaw { get; private set; }
    public sbyte Pitch { get; private set; }
    public bool OnGround { get; private set; }

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

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Yaw = reader.ReadSByte();
        Pitch = reader.ReadSByte();
        OnGround = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteSByte(Yaw);
        writer.WriteSByte(Pitch);
        writer.WriteBool(OnGround);
	}
}
