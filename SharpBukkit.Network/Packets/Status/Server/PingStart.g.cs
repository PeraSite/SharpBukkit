// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Status;

public record StatusServerPingStart : IPacket {

    public byte PacketId => 0x00;

    

    public StatusServerPingStart(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public StatusServerPingStart(
		
		) {
		
	}

	public void Serialize(IMinecraftReader reader) {
		
	}

	public void Deserialize(IMinecraftWriter writer) {
		
	}
}