// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientAnimation : IPacket {

    public byte PacketId => 0x06;

    public int EntityId { get; private set; }
    public byte Animation { get; private set; }

	public PlayClientAnimation(
		int entityId,
		byte animation
		) {
		EntityId = entityId;
		Animation = animation;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Animation = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteByte(Animation);
	}
}