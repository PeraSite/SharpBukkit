// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSetDifficulty : IPacket {

    public byte PacketId => 0x02;

    public byte NewDifficulty { get; private set; }

	public PlayServerSetDifficulty(
		byte newDifficulty
		) {
		NewDifficulty = newDifficulty;
	}

	public void Serialize(IMinecraftReader reader) {
		NewDifficulty = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(NewDifficulty);
	}
}
