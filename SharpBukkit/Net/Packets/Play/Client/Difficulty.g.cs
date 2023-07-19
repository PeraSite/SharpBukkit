// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientDifficulty : IPacket {

    public byte PacketId => 0x0e;

    public byte Difficulty { get; private set; }
    public bool DifficultyLocked { get; private set; }

    public PlayClientDifficulty(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientDifficulty(
		byte difficulty,
		bool difficultyLocked
		) {
		Difficulty = difficulty;
		DifficultyLocked = difficultyLocked;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(Difficulty);
        writer.WriteBool(DifficultyLocked);
	}

	public void Deserialize(IMinecraftReader reader) {
		Difficulty = reader.ReadByte();
        DifficultyLocked = reader.ReadBool();
	}
}
