// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientScoreboardDisplayObjective : IPacket {

    public byte PacketId => 0x4c;

    public sbyte Position { get; private set; }
    public string Name { get; private set; }

    public PlayClientScoreboardDisplayObjective(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientScoreboardDisplayObjective(
		sbyte position,
		string name
		) {
		Position = position;
		Name = name;
	}

	public void Serialize(IMinecraftReader reader) {
		Position = reader.ReadSByte();
        Name = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteSByte(Position);
        writer.WriteString(Name);
	}
}