// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Status;

public record StatusClientPing : IPacket {

    public byte PacketId => 0x01;

    public long Time { get; private set; }

    public StatusClientPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusClientPing(
		long time
		) {
		Time = time;
	}

	public void Deserialize(IMinecraftReader reader) {
		Time = reader.ReadLong();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(Time);
	}
}
