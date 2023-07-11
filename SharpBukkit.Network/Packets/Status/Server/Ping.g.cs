// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Status;

public record StatusServerPing : IPacket {

    public byte PacketId => 0x01;

    public long Time { get; private set; }

	public StatusServerPing(
		long time
		) {
		Time = time;
	}

	public void Serialize(IMinecraftReader reader) {
		Time = reader.ReadLong();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteLong(Time);
	}
}
