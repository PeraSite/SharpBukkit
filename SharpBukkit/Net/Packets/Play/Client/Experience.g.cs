// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientExperience : IPacket {

    public byte PacketId => 0x51;

    public float ExperienceBar { get; private set; }
    public int Level { get; private set; }
    public int TotalExperience { get; private set; }

    public PlayClientExperience(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientExperience(
		float experienceBar,
		int level,
		int totalExperience
		) {
		ExperienceBar = experienceBar;
		Level = level;
		TotalExperience = totalExperience;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteFloat(ExperienceBar);
        writer.WriteVarInt(Level);
        writer.WriteVarInt(TotalExperience);
	}

	public void Deserialize(IMinecraftReader reader) {
		ExperienceBar = reader.ReadFloat();
        Level = reader.ReadVarInt();
        TotalExperience = reader.ReadVarInt();
	}
}
