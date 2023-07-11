// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSpectate : IPacket {

    public byte PacketId => 0x2d;

    public Guid Target { get; private set; }

    public PlayServerSpectate(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerSpectate(
		Guid target
		) {
		Target = target;
	}

	public void Serialize(IMinecraftReader reader) {
		Target = reader.ReadUuid();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteUuid(Target);
	}
}