// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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