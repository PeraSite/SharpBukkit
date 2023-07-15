// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientRespawn : IPacket {

    public byte PacketId => 0x3d;

    public Dimension Dimension { get; private set; }
    public string WorldName { get; private set; }
    public long HashedSeed { get; private set; }
    public byte Gamemode { get; private set; }
    public byte PreviousGamemode { get; private set; }
    public bool IsDebug { get; private set; }
    public bool IsFlat { get; private set; }
    public bool CopyMetadata { get; private set; }

    public PlayClientRespawn(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientRespawn(
		Dimension dimension,
		string worldName,
		long hashedSeed,
		byte gamemode,
		byte previousGamemode,
		bool isDebug,
		bool isFlat,
		bool copyMetadata
		) {
		Dimension = dimension;
		WorldName = worldName;
		HashedSeed = hashedSeed;
		Gamemode = gamemode;
		PreviousGamemode = previousGamemode;
		IsDebug = isDebug;
		IsFlat = isFlat;
		CopyMetadata = copyMetadata;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteNbt<Dimension>(Dimension);
        writer.WriteString(WorldName);
        writer.WriteLong(HashedSeed);
        writer.WriteByte(Gamemode);
        writer.WriteByte(PreviousGamemode);
        writer.WriteBool(IsDebug);
        writer.WriteBool(IsFlat);
        writer.WriteBool(CopyMetadata);
	}

	public void Deserialize(IMinecraftReader reader) {
		Dimension = reader.ReadNbt<Dimension>();
        WorldName = reader.ReadString();
        HashedSeed = reader.ReadLong();
        Gamemode = reader.ReadByte();
        PreviousGamemode = reader.ReadByte();
        IsDebug = reader.ReadBool();
        IsFlat = reader.ReadBool();
        CopyMetadata = reader.ReadBool();
	}
}