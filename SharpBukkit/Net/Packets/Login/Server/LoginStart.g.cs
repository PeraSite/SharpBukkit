// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record LoginServerLoginStart : IPacket {

    public byte PacketId => 0x00;

    public string Username { get; private set; }

    public LoginServerLoginStart(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public LoginServerLoginStart(
		string username
		) {
		Username = username;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Username);
	}

	public void Deserialize(IMinecraftReader reader) {
		Username = reader.ReadString();
	}
}
