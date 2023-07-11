// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerLockDifficulty : IPacket {

    public byte PacketId => 0x10;

    public bool Locked { get; private set; }

	public PlayServerLockDifficulty(
		bool locked
		) {
		Locked = locked;
	}

	public void Serialize(IMinecraftReader reader) {
		Locked = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteBool(Locked);
	}
}