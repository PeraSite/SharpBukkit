// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientVehicleMove : IPacket {

    public byte PacketId => 0x2c;

    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }

	public PlayClientVehicleMove(
		double x,
		double y,
		double z,
		float yaw,
		float pitch
		) {
		X = x;
		Y = y;
		Z = z;
		Yaw = yaw;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
	}
}
