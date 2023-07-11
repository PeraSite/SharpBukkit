// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientKickDisconnect : IPacket {

    public byte PacketId => 0x1a;

    public string Reason { get; private set; }

	public PlayClientKickDisconnect(
		string reason
		) {
		Reason = reason;
	}

	public void Serialize(IMinecraftReader reader) {
		Reason = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Reason);
	}
}
