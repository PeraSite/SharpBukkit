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

    public byte[] SharedSecret { get; private set; }
    public byte[] VerifyToken { get; private set; }

    public LoginServerEncryptionBegin(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginServerEncryptionBegin(
		byte[] sharedSecret,
		byte[] verifyToken
		) {
		SharedSecret = sharedSecret;
		VerifyToken = verifyToken;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByteArray(SharedSecret);
        writer.WriteByteArray(VerifyToken);
	}

	public void Deserialize(IMinecraftReader reader) {
		SharedSecret = reader.ReadByteArray();
        VerifyToken = reader.ReadByteArray();
	}
}