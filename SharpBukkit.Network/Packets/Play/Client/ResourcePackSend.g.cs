// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientResourcePackSend : IPacket {

    public byte PacketId => 0x3c;

    public string Url { get; private set; }
    public string Hash { get; private set; }
    public bool Forced { get; private set; }

	public PlayClientResourcePackSend(
		string url,
		string hash,
		bool forced
		) {
		Url = url;
		Hash = hash;
		Forced = forced;
	}

	public void Serialize(IMinecraftReader reader) {
		Url = reader.ReadString();
        Hash = reader.ReadString();
        Forced = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Url);
        writer.WriteString(Hash);
        writer.WriteBool(Forced);
	}
}