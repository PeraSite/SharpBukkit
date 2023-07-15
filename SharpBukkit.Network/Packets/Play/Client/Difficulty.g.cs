// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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