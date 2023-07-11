// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientExplosion : IPacket {

    public byte PacketId => 0x1c;

    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public float Radius { get; private set; }
    public float PlayerMotionX { get; private set; }
    public float PlayerMotionY { get; private set; }
    public float PlayerMotionZ { get; private set; }

    public PlayClientExplosion(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientExplosion(
		float x,
		float y,
		float z,
		float radius,
		float playerMotionX,
		float playerMotionY,
		float playerMotionZ
		) {
		X = x;
		Y = y;
		Z = z;
		Radius = radius;
		PlayerMotionX = playerMotionX;
		PlayerMotionY = playerMotionY;
		PlayerMotionZ = playerMotionZ;
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadFloat();
        Y = reader.ReadFloat();
        Z = reader.ReadFloat();
        Radius = reader.ReadFloat();
        PlayerMotionX = reader.ReadFloat();
        PlayerMotionY = reader.ReadFloat();
        PlayerMotionZ = reader.ReadFloat();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteFloat(X);
        writer.WriteFloat(Y);
        writer.WriteFloat(Z);
        writer.WriteFloat(Radius);
        writer.WriteFloat(PlayerMotionX);
        writer.WriteFloat(PlayerMotionY);
        writer.WriteFloat(PlayerMotionZ);
	}
}
