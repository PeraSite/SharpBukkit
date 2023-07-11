// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityUpdateAttributes : IPacket {

    public byte PacketId => 0x64;

    public int EntityId { get; private set; }

	public PlayClientEntityUpdateAttributes(
		int entityId
		) {
		EntityId = entityId;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
	}
}
