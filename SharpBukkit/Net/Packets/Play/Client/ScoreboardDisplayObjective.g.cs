// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientScoreboardDisplayObjective : IPacket {

    public byte PacketId => 0x4c;

    public sbyte Position { get; private set; }
    public string Name { get; private set; }

    public PlayClientScoreboardDisplayObjective(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientScoreboardDisplayObjective(
		sbyte position,
		string name
		) {
		Position = position;
		Name = name;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Position);
        writer.WriteString(Name);
	}

	public void Deserialize(IMinecraftReader reader) {
		Position = reader.ReadSByte();
        Name = reader.ReadString();
	}
}
