// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientTags : IPacket {

    public byte PacketId => 0x67;

    

    public PlayClientTags(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientTags(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}
