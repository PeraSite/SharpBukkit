// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUpdateStructureBlock : IPacket {

    public byte PacketId => 0x2a;

    public Vector3 Location { get; private set; }
    public int Action { get; private set; }
    public int Mode { get; private set; }
    public string Name { get; private set; }
    public sbyte OffsetX { get; private set; }
    public sbyte OffsetY { get; private set; }
    public sbyte OffsetZ { get; private set; }
    public sbyte SizeX { get; private set; }
    public sbyte SizeY { get; private set; }
    public sbyte SizeZ { get; private set; }
    public int Mirror { get; private set; }
    public int Rotation { get; private set; }
    public string Metadata { get; private set; }
    public float Integrity { get; private set; }
    public long Seed { get; private set; }
    public byte Flags { get; private set; }

    public PlayServerUpdateStructureBlock(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerUpdateStructureBlock(
		Vector3 location,
		int action,
		int mode,
		string name,
		sbyte offsetX,
		sbyte offsetY,
		sbyte offsetZ,
		sbyte sizeX,
		sbyte sizeY,
		sbyte sizeZ,
		int mirror,
		int rotation,
		string metadata,
		float integrity,
		long seed,
		byte flags
		) {
		Location = location;
		Action = action;
		Mode = mode;
		Name = name;
		OffsetX = offsetX;
		OffsetY = offsetY;
		OffsetZ = offsetZ;
		SizeX = sizeX;
		SizeY = sizeY;
		SizeZ = sizeZ;
		Mirror = mirror;
		Rotation = rotation;
		Metadata = metadata;
		Integrity = integrity;
		Seed = seed;
		Flags = flags;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Action = reader.ReadVarInt();
        Mode = reader.ReadVarInt();
        Name = reader.ReadString();
        OffsetX = reader.ReadSByte();
        OffsetY = reader.ReadSByte();
        OffsetZ = reader.ReadSByte();
        SizeX = reader.ReadSByte();
        SizeY = reader.ReadSByte();
        SizeZ = reader.ReadSByte();
        Mirror = reader.ReadVarInt();
        Rotation = reader.ReadVarInt();
        Metadata = reader.ReadString();
        Integrity = reader.ReadFloat();
        Seed = reader.ReadLong();
        Flags = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Action);
        writer.WriteVarInt(Mode);
        writer.WriteString(Name);
        writer.WriteSByte(OffsetX);
        writer.WriteSByte(OffsetY);
        writer.WriteSByte(OffsetZ);
        writer.WriteSByte(SizeX);
        writer.WriteSByte(SizeY);
        writer.WriteSByte(SizeZ);
        writer.WriteVarInt(Mirror);
        writer.WriteVarInt(Rotation);
        writer.WriteString(Metadata);
        writer.WriteFloat(Integrity);
        writer.WriteLong(Seed);
        writer.WriteByte(Flags);
	}
}