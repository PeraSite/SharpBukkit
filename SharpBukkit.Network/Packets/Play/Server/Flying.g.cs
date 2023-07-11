// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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

	public void Deserialize(IMinecraftReader reader) {
		OnGround = reader.ReadBool();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(OnGround);
	}
}
