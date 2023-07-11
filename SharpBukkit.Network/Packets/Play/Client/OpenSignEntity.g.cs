// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientOpenSignEntity : IPacket {

    public byte PacketId => 0x2f;

    public Vector3 Location { get; private set; }

	public PlayClientOpenSignEntity(
		Vector3 location
		) {
		Location = location;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
	}
}
