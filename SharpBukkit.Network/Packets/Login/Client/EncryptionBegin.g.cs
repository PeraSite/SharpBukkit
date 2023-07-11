// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginClientEncryptionBegin : IPacket {

    public byte PacketId => 0x01;

    public string ServerId { get; private set; }

	public LoginClientEncryptionBegin(
		string serverId
		) {
		ServerId = serverId;
	}

	public void Serialize(IMinecraftReader reader) {
		ServerId = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(ServerId);
	}
}
