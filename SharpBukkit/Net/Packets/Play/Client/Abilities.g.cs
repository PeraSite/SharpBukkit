// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientAbilities : IPacket {

    public byte PacketId => 0x32;

    public sbyte Flags { get; private set; }
    public float FlyingSpeed { get; private set; }
    public float WalkingSpeed { get; private set; }

    public PlayClientAbilities(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAbilities(
		sbyte flags,
		float flyingSpeed,
		float walkingSpeed
		) {
		Flags = flags;
		FlyingSpeed = flyingSpeed;
		WalkingSpeed = walkingSpeed;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteSByte(Flags);
        writer.WriteFloat(FlyingSpeed);
        writer.WriteFloat(WalkingSpeed);
	}

	public void Deserialize(IMinecraftReader reader) {
		Flags = reader.ReadSByte();
        FlyingSpeed = reader.ReadFloat();
        WalkingSpeed = reader.ReadFloat();
	}
}
