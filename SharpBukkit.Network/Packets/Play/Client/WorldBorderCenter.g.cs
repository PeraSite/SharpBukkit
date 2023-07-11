// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWorldBorderCenter : IPacket {

    public byte PacketId => 0x42;

    public double X { get; private set; }
    public double Z { get; private set; }

    public PlayClientWorldBorderCenter(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderCenter(
		double x,
		double z
		) {
		X = x;
		Z = z;
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Z = reader.ReadDouble();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Z);
	}
}
