// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUpdateTime : IPacket {

    public byte PacketId => 0x59;

    public long Age { get; private set; }
    public long Time { get; private set; }

    public PlayClientUpdateTime(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUpdateTime(
		long age,
		long time
		) {
		Age = age;
		Time = time;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteLong(Age);
        writer.WriteLong(Time);
	}

	public void Deserialize(IMinecraftReader reader) {
		Age = reader.ReadLong();
        Time = reader.ReadLong();
	}
}