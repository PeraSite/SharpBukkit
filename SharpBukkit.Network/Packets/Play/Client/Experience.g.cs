// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientExperience : IPacket {

    public byte PacketId => 0x51;

    public float ExperienceBar { get; private set; }
    public int Level { get; private set; }
    public int TotalExperience { get; private set; }

	public PlayClientExperience(
		float experienceBar,
		int level,
		int totalExperience
		) {
		ExperienceBar = experienceBar;
		Level = level;
		TotalExperience = totalExperience;
	}

	public void Serialize(IMinecraftReader reader) {
		ExperienceBar = reader.ReadFloat();
        Level = reader.ReadVarInt();
        TotalExperience = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteFloat(ExperienceBar);
        writer.WriteVarInt(Level);
        writer.WriteVarInt(TotalExperience);
	}
}
