// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginClientSuccess : IPacket {

    public byte PacketId => 0x02;

    public Guid Uuid { get; private set; }
    public string Username { get; private set; }

    public LoginClientSuccess(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginClientSuccess(
		Guid uuid,
		string username
		) {
		Uuid = uuid;
		Username = username;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteUuid(Uuid);
        writer.WriteString(Username);
	}

	public void Deserialize(IMinecraftReader reader) {
		Uuid = reader.ReadUuid();
        Username = reader.ReadString();
	}
}
