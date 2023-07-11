// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientScoreboardScore : IPacket {

    public byte PacketId => 0x56;

    public string ItemName { get; private set; }
    public int Action { get; private set; }
    public string ScoreName { get; private set; }

	public PlayClientScoreboardScore(
		string itemName,
		int action,
		string scoreName
		) {
		ItemName = itemName;
		Action = action;
		ScoreName = scoreName;
	}

	public void Serialize(IMinecraftReader reader) {
		ItemName = reader.ReadString();
        Action = reader.ReadVarInt();
        ScoreName = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(ItemName);
        writer.WriteVarInt(Action);
        writer.WriteString(ScoreName);
	}
}
