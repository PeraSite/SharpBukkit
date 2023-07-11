// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientClearTitles : IPacket {

    public byte PacketId => 0x10;

    public bool Reset { get; private set; }

	public PlayClientClearTitles(
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
