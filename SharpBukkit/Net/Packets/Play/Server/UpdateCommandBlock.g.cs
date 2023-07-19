// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerUpdateCommandBlock : IPacket {

    public byte PacketId => 0x26;

    public Vector3 Location { get; private set; }
    public string Command { get; private set; }
    public int Mode { get; private set; }
    public byte Flags { get; private set; }

    public PlayServerUpdateCommandBlock(IMinecraftReader reader) {
	    Deserialize(reader);
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

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteString(Command);
        writer.WriteVarInt(Mode);
        writer.WriteByte(Flags);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Command = reader.ReadString();
        Mode = reader.ReadVarInt();
        Flags = reader.ReadByte();
	}
}
