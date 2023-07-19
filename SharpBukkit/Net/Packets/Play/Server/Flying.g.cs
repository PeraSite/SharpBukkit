// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerFlying : IPacket {

    public byte PacketId => 0x14;

    public bool OnGround { get; private set; }

    public PlayServerFlying(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerFlying(
		bool onGround
		) {
		OnGround = onGround;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(OnGround);
	}

	public void Deserialize(IMinecraftReader reader) {
		OnGround = reader.ReadBool();
	}
}
