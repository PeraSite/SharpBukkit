// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginClientSuccess : IPacket {

    public byte PacketId => 0x02;

    public Guid Uuid { get; private set; }
    public string Username { get; private set; }

	public LoginClientSuccess(
		Guid uuid,
		string username
		) {
		Uuid = uuid;
		Username = username;
	}

	public void Serialize(IMinecraftReader reader) {
		Uuid = reader.ReadUuid();
        Username = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteUuid(Uuid);
        writer.WriteString(Username);
	}
}
