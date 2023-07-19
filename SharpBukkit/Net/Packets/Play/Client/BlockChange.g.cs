// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientBlockChange : IPacket {

    public byte PacketId => 0x0c;

    public Vector3 Location { get; private set; }
    public int Type { get; private set; }

    public PlayClientBlockChange(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientBlockChange(
		Vector3 location,
		int type
		) {
		Location = location;
		Type = type;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Type);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Type = reader.ReadVarInt();
	}
}
