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
	    Serialize(reader);
    }

	public PlayClientStopSound(
		sbyte flags
		) {
		Flags = flags;
	}

	public void Serialize(IMinecraftReader reader) {
		Flags = reader.ReadSByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteSByte(Flags);
	}
}