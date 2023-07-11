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
	    Serialize(reader);
    }

	public StatusClientPing(
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