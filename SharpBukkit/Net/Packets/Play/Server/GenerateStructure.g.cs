// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerGenerateStructure : IPacket {

    public byte PacketId => 0x0e;

    public Vector3 Location { get; private set; }
    public int Levels { get; private set; }
    public bool KeepJigsaws { get; private set; }

    public PlayServerGenerateStructure(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerGenerateStructure(
		Vector3 location,
		int levels,
		bool keepJigsaws
		) {
		Location = location;
		Levels = levels;
		KeepJigsaws = keepJigsaws;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Levels);
        writer.WriteBool(KeepJigsaws);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Levels = reader.ReadVarInt();
        KeepJigsaws = reader.ReadBool();
	}
}
