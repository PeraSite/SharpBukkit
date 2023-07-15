// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Status;

public record StatusClientServerInfo : IPacket {

    public byte PacketId => 0x00;

    public string Response { get; private set; }

    public StatusClientServerInfo(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusClientServerInfo(
		string response
		) {
		Response = response;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Response);
	}

	public void Deserialize(IMinecraftReader reader) {
		Response = reader.ReadString();
	}
}