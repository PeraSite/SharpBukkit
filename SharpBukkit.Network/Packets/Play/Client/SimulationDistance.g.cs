// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSimulationDistance : IPacket {

    public byte PacketId => 0x57;

    public int Distance { get; private set; }

	public PlayClientSimulationDistance(
		int distance
		) {
		Distance = distance;
	}

	public void Serialize(IMinecraftReader reader) {
		Distance = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Distance);
	}
}
