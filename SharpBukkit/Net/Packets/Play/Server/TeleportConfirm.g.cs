// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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
