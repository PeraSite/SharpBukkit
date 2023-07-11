// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUseEntity : IPacket {

    public byte PacketId => 0x0d;

    public int Target { get; private set; }
    public int Mouse { get; private set; }
    public bool Sneaking { get; private set; }

    public PlayServerUseEntity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUseEntity(
		int target,
		int mouse,
		bool sneaking
		) {
		Target = target;
		Mouse = mouse;
		Sneaking = sneaking;
	}

	public void Deserialize(IMinecraftReader reader) {
		Target = reader.ReadVarInt();
        Mouse = reader.ReadVarInt();
        Sneaking = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Target);
        writer.WriteVarInt(Mouse);
        writer.WriteBool(Sneaking);
	}
}
