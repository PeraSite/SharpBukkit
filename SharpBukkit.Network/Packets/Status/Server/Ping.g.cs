// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Status;

public record StatusServerPing : IPacket {

    public byte PacketId => 0x01;

    public long Time { get; private set; }

    public StatusServerPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusServerPing(
		long time
		) {
		Time = time;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(Time);
	}

	public void Deserialize(IMinecraftReader reader) {
		Time = reader.ReadLong();
	}
}