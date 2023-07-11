// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUpdateCommandBlock : IPacket {

    public byte PacketId => 0x26;

    public Vector3 Location { get; private set; }
    public string Command { get; private set; }
    public int Mode { get; private set; }
    public byte Flags { get; private set; }

    public PlayServerUpdateCommandBlock(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerUpdateCommandBlock(
		Vector3 location,
		string command,
		int mode,
		byte flags
		) {
		Location = location;
		Command = command;
		Mode = mode;
		Flags = flags;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Command = reader.ReadString();
        Mode = reader.ReadVarInt();
        Flags = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteString(Command);
        writer.WriteVarInt(Mode);
        writer.WriteByte(Flags);
	}
}