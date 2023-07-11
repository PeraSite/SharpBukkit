// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientScoreboardObjective : IPacket {

    public byte PacketId => 0x53;

    public string Name { get; private set; }
    public sbyte Action { get; private set; }

	public PlayClientScoreboardObjective(
		string name,
		sbyte action
		) {
		Name = name;
		Action = action;
	}

	public void Serialize(IMinecraftReader reader) {
		Name = reader.ReadString();
        Action = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Name);
        writer.WriteSByte(Action);
	}
}
