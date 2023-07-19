// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientGameStateChange : IPacket {

    public byte PacketId => 0x1e;

    public byte Reason { get; private set; }
    public float GameMode { get; private set; }

    public PlayClientGameStateChange(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientGameStateChange(
		byte reason,
		float gameMode
		) {
		Reason = reason;
		GameMode = gameMode;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(Reason);
        writer.WriteFloat(GameMode);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reason = reader.ReadByte();
        GameMode = reader.ReadFloat();
	}
}
