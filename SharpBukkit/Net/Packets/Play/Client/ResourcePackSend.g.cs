// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientResourcePackSend : IPacket {

    public byte PacketId => 0x3c;

    public string Url { get; private set; }
    public string Hash { get; private set; }
    public bool Forced { get; private set; }

    public PlayClientResourcePackSend(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientResourcePackSend(
		string url,
		string hash,
		bool forced
		) {
		Url = url;
		Hash = hash;
		Forced = forced;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Url);
        writer.WriteString(Hash);
        writer.WriteBool(Forced);
	}

	public void Deserialize(IMinecraftReader reader) {
		Url = reader.ReadString();
        Hash = reader.ReadString();
        Forced = reader.ReadBool();
	}
}
