// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSpawnPosition : IPacket {

    public byte PacketId => 0x4b;

    public Vector3 Location { get; private set; }
    public float Angle { get; private set; }

	public PlayClientSpawnPosition(
		Vector3 location,
		float angle
		) {
		Location = location;
		Angle = angle;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Angle = reader.ReadFloat();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteFloat(Angle);
	}
}
