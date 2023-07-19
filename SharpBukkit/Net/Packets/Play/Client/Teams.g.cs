// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientTeams : IPacket {

    public byte PacketId => 0x55;

    public string Team { get; private set; }
    public sbyte Mode { get; private set; }

    public PlayClientTeams(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientTeams(
		string team,
		sbyte mode
		) {
		Team = team;
		Mode = mode;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Team);
        writer.WriteSByte(Mode);
	}

	public void Deserialize(IMinecraftReader reader) {
		Team = reader.ReadString();
        Mode = reader.ReadSByte();
	}
}
