// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientStopSound : IPacket {

    public byte PacketId => 0x5e;

    public sbyte Flags { get; private set; }

    public PlayClientStopSound(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientStopSound(
		sbyte flags
		) {
		Flags = flags;
	}

	public void Deserialize(IMinecraftReader reader) {
		Flags = reader.ReadSByte();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Flags);
	}
}
