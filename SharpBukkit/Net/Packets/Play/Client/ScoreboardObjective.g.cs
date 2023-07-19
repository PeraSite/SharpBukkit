// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientScoreboardObjective : IPacket {

    public byte PacketId => 0x53;

    public string Name { get; private set; }
    public sbyte Action { get; private set; }

    public PlayClientScoreboardObjective(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientScoreboardObjective(
		string name,
		sbyte action
		) {
		Name = name;
		Action = action;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Name);
        writer.WriteSByte(Action);
	}

	public void Deserialize(IMinecraftReader reader) {
		Name = reader.ReadString();
        Action = reader.ReadSByte();
	}
}
