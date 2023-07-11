// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerLook : IPacket {

    public byte PacketId => 0x13;

    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayServerLook(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerLook(
		float yaw,
		float pitch,
		bool onGround
		) {
		Yaw = yaw;
		Pitch = pitch;
		OnGround = onGround;
	}

	public void Serialize(IMinecraftReader reader) {
		Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        OnGround = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
        writer.WriteBool(OnGround);
	}
}