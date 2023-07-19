// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerLockDifficulty : IPacket {

    public byte PacketId => 0x10;

    public bool Locked { get; private set; }

    public PlayServerLockDifficulty(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerLockDifficulty(
		bool locked
		) {
		Locked = locked;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Locked);
	}

	public void Deserialize(IMinecraftReader reader) {
		Locked = reader.ReadBool();
	}
}
