// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerLockDifficulty : IPacket {

    public byte PacketId => 0x10;

    public bool Locked { get; private set; }

    public PlayServerLockDifficulty(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerLockDifficulty(
		bool locked
		) {
		Locked = locked;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Locked);
	}

	public void Deserialize(IMinecraftReader reader) {
		Locked = reader.ReadBool();
	}
}