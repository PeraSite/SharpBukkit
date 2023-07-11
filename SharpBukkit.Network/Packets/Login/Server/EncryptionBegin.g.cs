// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginServerEncryptionBegin : IPacket {

    public byte PacketId => 0x01;

    

    public LoginServerEncryptionBegin(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public LoginServerEncryptionBegin(
		
		) {
		
	}

	public void Serialize(IMinecraftReader reader) {
		
	}

	public void Deserialize(IMinecraftWriter writer) {
		
	}
}