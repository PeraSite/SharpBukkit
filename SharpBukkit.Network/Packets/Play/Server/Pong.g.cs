// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerPong : IPacket {

    public byte PacketId => 0x1d;

    public int Id { get; private set; }

	public PlayServerPong(
		int id
		) {
		Id = id;
	}

	public void Serialize(IMinecraftReader reader) {
		Id = reader.ReadInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(Id);
	}
}
