// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginClientDisconnect : IPacket {

    public byte PacketId => 0x00;

    public string Reason { get; private set; }

    public LoginClientDisconnect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientDisconnect(
		string reason
		) {
		Reason = reason;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Reason);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reason = reader.ReadString();
	}
}