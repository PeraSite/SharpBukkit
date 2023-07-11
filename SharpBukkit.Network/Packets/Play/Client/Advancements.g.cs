// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientAdvancements : IPacket {

    public byte PacketId => 0x63;

    public bool Reset { get; private set; }

	public PlayClientAdvancements(
		bool reset
		) {
		Reset = reset;
	}

	public void Serialize(IMinecraftReader reader) {
		Reset = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteBool(Reset);
	}
}
