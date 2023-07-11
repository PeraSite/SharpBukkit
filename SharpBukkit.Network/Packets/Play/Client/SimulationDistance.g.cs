// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSimulationDistance : IPacket {

    public byte PacketId => 0x57;

    public int Distance { get; private set; }

    public PlayClientSimulationDistance(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSimulationDistance(
		int distance
		) {
		Distance = distance;
	}

	public void Deserialize(IMinecraftReader reader) {
		Distance = reader.ReadVarInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Distance);
	}
}
