// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientDeclareRecipes : IPacket {

    public byte PacketId => 0x66;

    

    public PlayClientDeclareRecipes(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientDeclareRecipes(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}
