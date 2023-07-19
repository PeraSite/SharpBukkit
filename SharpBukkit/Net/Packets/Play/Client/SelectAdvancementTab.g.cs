// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSelectAdvancementTab : IPacket {

    public byte PacketId => 0x40;

    

    public PlayClientSelectAdvancementTab(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSelectAdvancementTab(
		
		) {
		
	}

	public void Serialize(IMinecraftWriter writer) {
		
	}

	public void Deserialize(IMinecraftReader reader) {
		
	}
}
