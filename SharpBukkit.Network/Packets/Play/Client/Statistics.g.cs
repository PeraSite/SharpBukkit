// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientStatistics : IPacket {

    public byte PacketId => 0x07;

    

    public PlayClientStatistics(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientStatistics(
		
		) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}
}
