// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUpdateJigsawBlock : IPacket {

    public byte PacketId => 0x29;

    public Vector3 Location { get; private set; }
    public string Name { get; private set; }
    public string Target { get; private set; }
    public string Pool { get; private set; }
    public string FinalState { get; private set; }
    public string JointType { get; private set; }

    public PlayServerUpdateJigsawBlock(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUpdateJigsawBlock(
		Vector3 location,
		string name,
		string target,
		string pool,
		string finalState,
		string jointType
		) {
		Location = location;
		Name = name;
		Target = target;
		Pool = pool;
		FinalState = finalState;
		JointType = jointType;
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Name = reader.ReadString();
        Target = reader.ReadString();
        Pool = reader.ReadString();
        FinalState = reader.ReadString();
        JointType = reader.ReadString();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteString(Name);
        writer.WriteString(Target);
        writer.WriteString(Pool);
        writer.WriteString(FinalState);
        writer.WriteString(JointType);
	}
}
