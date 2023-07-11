// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerFlying : IPacket {

    public byte PacketId => 0x14;

    public bool OnGround { get; private set; }

	public PlayServerFlying(
		bool onGround
		) {
		OnGround = onGround;
	}

	public void Serialize(IMinecraftReader reader) {
		OnGround = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteBool(OnGround);
	}
}
