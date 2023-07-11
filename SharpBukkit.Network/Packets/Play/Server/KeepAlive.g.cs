// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerKeepAlive : IPacket {

    public byte PacketId => 0x0f;

    public long KeepAliveId { get; private set; }

    public PlayServerKeepAlive(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerKeepAlive(
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
