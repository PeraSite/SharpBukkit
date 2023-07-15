// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientPing : IPacket {

    public byte PacketId => 0x30;

    public int Id { get; private set; }

    public PlayClientPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientPing(
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