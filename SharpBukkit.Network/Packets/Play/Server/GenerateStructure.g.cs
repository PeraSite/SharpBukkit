// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerGenerateStructure : IPacket {

    public byte PacketId => 0x0e;

    public Vector3 Location { get; private set; }
    public int Levels { get; private set; }
    public bool KeepJigsaws { get; private set; }

    public PlayServerGenerateStructure(IMinecraftReader reader) {
	    Serialize(reader);
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

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Levels = reader.ReadVarInt();
        KeepJigsaws = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Levels);
        writer.WriteBool(KeepJigsaws);
	}
}