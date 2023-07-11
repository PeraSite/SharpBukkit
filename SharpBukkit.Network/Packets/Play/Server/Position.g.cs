// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerPosition : IPacket {

    public byte PacketId => 0x11;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public bool OnGround { get; private set; }

    public PlayServerPosition(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPosition(
		double x,
		double y,
		double z,
		bool onGround
		) {
		X = x;
		Y = y;
		Z = z;
		OnGround = onGround;
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        OnGround = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteBool(OnGround);
	}
}
