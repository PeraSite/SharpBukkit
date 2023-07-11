// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientBlockBreakAnimation : IPacket {

    public byte PacketId => 0x09;

    public int EntityId { get; private set; }
    public Vector3 Location { get; private set; }
    public sbyte DestroyStage { get; private set; }

	public PlayClientBlockBreakAnimation(
		int entityId,
		Vector3 location,
		sbyte destroyStage
		) {
		EntityId = entityId;
		Location = location;
		DestroyStage = destroyStage;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Location = reader.ReadPosition();
        DestroyStage = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WritePosition(Location);
        writer.WriteSByte(DestroyStage);
	}
}
