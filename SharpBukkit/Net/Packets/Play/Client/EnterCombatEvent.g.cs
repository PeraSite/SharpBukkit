// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEnterCombatEvent : IPacket {

    public byte PacketId => 0x34;

    

    public PlayClientEnterCombatEvent(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEnterCombatEvent(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}
