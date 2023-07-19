// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientBlockAction : IPacket {

    public byte PacketId => 0x0b;

    public Vector3 Location { get; private set; }
    public byte Byte1 { get; private set; }
    public byte Byte2 { get; private set; }
    public int BlockId { get; private set; }

    public PlayClientBlockAction(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientBlockAction(
		Vector3 location,
		byte byte1,
		byte byte2,
		int blockId
		) {
		Location = location;
		Byte1 = byte1;
		Byte2 = byte2;
		BlockId = blockId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteByte(Byte1);
        writer.WriteByte(Byte2);
        writer.WriteVarInt(BlockId);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Byte1 = reader.ReadByte();
        Byte2 = reader.ReadByte();
        BlockId = reader.ReadVarInt();
	}
}
