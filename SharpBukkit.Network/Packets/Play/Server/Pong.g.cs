// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerPong : IPacket {

    public byte PacketId => 0x1d;

    public int Id { get; private set; }

    public PlayServerPong(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPong(
		int id
		) {
		Id = id;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(Id);
	}

	public void Deserialize(IMinecraftReader reader) {
		Id = reader.ReadInt();
	}
}