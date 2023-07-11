// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientKeepAlive : IPacket {

    public byte PacketId => 0x21;

    public long KeepAliveId { get; private set; }

    public PlayClientKeepAlive(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientKeepAlive(
		long keepAliveId
		) {
		KeepAliveId = keepAliveId;
	}

	public void Deserialize(IMinecraftReader reader) {
		KeepAliveId = reader.ReadLong();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(KeepAliveId);
	}
}
