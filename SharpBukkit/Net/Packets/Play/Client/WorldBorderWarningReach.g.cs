// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldBorderWarningReach : IPacket {

    public byte PacketId => 0x46;

    public int WarningBlocks { get; private set; }

    public PlayClientWorldBorderWarningReach(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderWarningReach(
		int warningBlocks
		) {
		WarningBlocks = warningBlocks;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WarningBlocks);
	}

	public void Deserialize(IMinecraftReader reader) {
		WarningBlocks = reader.ReadVarInt();
	}
}
