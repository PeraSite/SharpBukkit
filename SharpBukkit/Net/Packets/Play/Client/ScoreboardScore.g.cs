// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientScoreboardScore : IPacket {

    public byte PacketId => 0x56;

    public string ItemName { get; private set; }
    public int Action { get; private set; }
    public string ScoreName { get; private set; }

    public PlayClientScoreboardScore(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientScoreboardScore(
		string itemName,
		int action,
		string scoreName
		) {
		ItemName = itemName;
		Action = action;
		ScoreName = scoreName;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(ItemName);
        writer.WriteVarInt(Action);
        writer.WriteString(ScoreName);
	}

	public void Deserialize(IMinecraftReader reader) {
		ItemName = reader.ReadString();
        Action = reader.ReadVarInt();
        ScoreName = reader.ReadString();
	}
}
