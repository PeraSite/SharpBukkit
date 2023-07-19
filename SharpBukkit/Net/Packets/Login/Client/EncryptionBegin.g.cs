// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginClientEncryptionBegin : IPacket {

    public byte PacketId => 0x01;

    public string ServerId { get; private set; }
    public byte[] PublicKey { get; private set; }
    public byte[] VerifyToken { get; private set; }

    public LoginClientEncryptionBegin(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientEncryptionBegin(
		string serverId,
		byte[] publicKey,
		byte[] verifyToken
		) {
		ServerId = serverId;
		PublicKey = publicKey;
		VerifyToken = verifyToken;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(ServerId);
        writer.WriteByteArray(PublicKey);
        writer.WriteByteArray(VerifyToken);
	}

	public void Deserialize(IMinecraftReader reader) {
		ServerId = reader.ReadString();
        PublicKey = reader.ReadByteArray();
        VerifyToken = reader.ReadByteArray();
	}
}
