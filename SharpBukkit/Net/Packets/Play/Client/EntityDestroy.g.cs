// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

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
