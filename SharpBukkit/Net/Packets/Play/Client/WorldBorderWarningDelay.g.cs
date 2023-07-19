// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldBorderWarningDelay : IPacket {

    public byte PacketId => 0x45;

    public int WarningTime { get; private set; }

    public PlayClientWorldBorderWarningDelay(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderWarningDelay(
		int warningTime
		) {
		WarningTime = warningTime;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WarningTime);
	}

	public void Deserialize(IMinecraftReader reader) {
		WarningTime = reader.ReadVarInt();
	}
}
