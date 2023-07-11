// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientDifficulty : IPacket {

    public byte PacketId => 0x0e;

    public byte Difficulty { get; private set; }
    public bool DifficultyLocked { get; private set; }

	public PlayClientDifficulty(
		byte difficulty,
		bool difficultyLocked
		) {
		Difficulty = difficulty;
		DifficultyLocked = difficultyLocked;
	}

	public void Serialize(IMinecraftReader reader) {
		Difficulty = reader.ReadByte();
        DifficultyLocked = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(Difficulty);
        writer.WriteBool(DifficultyLocked);
	}
}