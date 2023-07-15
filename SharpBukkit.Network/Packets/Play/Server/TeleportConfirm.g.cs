// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerTeleportConfirm : IPacket {

    public byte PacketId => 0x00;

    public int TeleportId { get; private set; }

    public PlayServerTeleportConfirm(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerTeleportConfirm(
		int teleportId
		) {
		TeleportId = teleportId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TeleportId);
	}

	public void Deserialize(IMinecraftReader reader) {
		TeleportId = reader.ReadVarInt();
	}
}