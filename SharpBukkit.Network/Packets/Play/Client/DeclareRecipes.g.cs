// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientDeclareRecipes : IPacket {

    public byte PacketId => 0x66;

    

    public PlayClientDeclareRecipes(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientDeclareRecipes(
		
		) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}
}
