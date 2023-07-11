// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginServerLoginStart : IPacket {

    public byte PacketId => 0x00;

    public string Username { get; private set; }

	public LoginServerLoginStart(
		string username
		) {
		Username = username;
	}

	public void Serialize(IMinecraftReader reader) {
		Username = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Username);
	}
}
