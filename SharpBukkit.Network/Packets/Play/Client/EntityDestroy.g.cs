// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntityDestroy : IPacket {

    public byte PacketId => 0x3a;

    

    public PlayClientEntityDestroy(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityDestroy(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}