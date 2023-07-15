// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUpdateViewDistance : IPacket {

    public byte PacketId => 0x4a;

    public int ViewDistance { get; private set; }

    public PlayClientUpdateViewDistance(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUpdateViewDistance(
		int viewDistance
		) {
		ViewDistance = viewDistance;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ViewDistance);
	}

	public void Deserialize(IMinecraftReader reader) {
		ViewDistance = reader.ReadVarInt();
	}
}