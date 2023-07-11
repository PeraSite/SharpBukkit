// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSelectAdvancementTab : IPacket {

    public byte PacketId => 0x40;

    

    public PlayClientSelectAdvancementTab(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientSelectAdvancementTab(
		
		) {
		
	}

	public void Serialize(IMinecraftReader reader) {
		
	}

	public void Deserialize(IMinecraftWriter writer) {
		
	}
}