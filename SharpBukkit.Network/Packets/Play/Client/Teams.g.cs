// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientTeams : IPacket {

    public byte PacketId => 0x55;

    public string Team { get; private set; }
    public sbyte Mode { get; private set; }

    public PlayClientTeams(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientTeams(
		string team,
		sbyte mode
		) {
		Team = team;
		Mode = mode;
	}

	public void Serialize(IMinecraftReader reader) {
		Team = reader.ReadString();
        Mode = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Team);
        writer.WriteSByte(Mode);
	}
}