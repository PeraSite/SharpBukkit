// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientAcknowledgePlayerDigging : IPacket {

    public byte PacketId => 0x08;

    public Vector3 Location { get; private set; }
    public int Block { get; private set; }
    public int Status { get; private set; }
    public bool Successful { get; private set; }

    public PlayClientAcknowledgePlayerDigging(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAcknowledgePlayerDigging(
		Vector3 location,
		int block,
		int status,
		bool successful
		) {
		Location = location;
		Block = block;
		Status = status;
		Successful = successful;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Block);
        writer.WriteVarInt(Status);
        writer.WriteBool(Successful);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Block = reader.ReadVarInt();
        Status = reader.ReadVarInt();
        Successful = reader.ReadBool();
	}
}
