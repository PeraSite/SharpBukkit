// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record StatusServerPingStart : IPacket {

    public byte PacketId => 0x00;

    

    public StatusServerPingStart(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public StatusServerPingStart(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}
