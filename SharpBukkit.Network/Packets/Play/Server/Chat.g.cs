// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerChat : IPacket {

    public byte PacketId => 0x03;

    public string Message { get; private set; }

	public PlayServerChat(
		string message
		) {
		Message = message;
	}

	public void Serialize(IMinecraftReader reader) {
		Message = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Message);
	}
}
