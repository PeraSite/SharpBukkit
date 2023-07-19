// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerBlockDig : IPacket {

    public byte PacketId => 0x1a;

    public int Status { get; private set; }
    public Vector3 Location { get; private set; }
    public sbyte Face { get; private set; }

    public PlayServerBlockDig(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerBlockDig(
		int status,
		Vector3 location,
		sbyte face
		) {
		Status = status;
		Location = location;
		Face = face;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Status);
        writer.WritePosition(Location);
        writer.WriteSByte(Face);
	}

	public void Deserialize(IMinecraftReader reader) {
		Status = reader.ReadVarInt();
        Location = reader.ReadPosition();
        Face = reader.ReadSByte();
	}
}
