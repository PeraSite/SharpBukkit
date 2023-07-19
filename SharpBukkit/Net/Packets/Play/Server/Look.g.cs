// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerLook : IPacket {

    public byte PacketId => 0x13;

    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public bool OnGround { get; private set; }

    public PlayServerLook(IMinecraftReader reader) {
	    Deserialize(reader);
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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteFloat(Yaw);
        writer.WriteFloat(Pitch);
        writer.WriteBool(OnGround);
	}

	public void Deserialize(IMinecraftReader reader) {
		Yaw = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        OnGround = reader.ReadBool();
	}
}
