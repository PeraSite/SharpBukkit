// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerAbilities : IPacket {

    public byte PacketId => 0x19;

    public sbyte Flags { get; private set; }

    public PlayServerAbilities(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerAbilities(
		sbyte flags
		) {
		Flags = flags;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Flags);
	}

	public void Deserialize(IMinecraftReader reader) {
		Flags = reader.ReadSByte();
	}
}