// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerTeleportConfirm : IPacket {

    public byte PacketId => 0x00;

    public int TeleportId { get; private set; }

	public PlayServerTeleportConfirm(
		int teleportId
		) {
		TeleportId = teleportId;
	}

	public void Serialize(IMinecraftReader reader) {
		TeleportId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TeleportId);
	}
}
