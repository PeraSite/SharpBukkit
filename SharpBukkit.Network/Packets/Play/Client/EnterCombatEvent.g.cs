// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEnterCombatEvent : IPacket {

    public byte PacketId => 0x34;

    

    public PlayClientEnterCombatEvent(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEnterCombatEvent(
		
		) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}
}
