// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerCustomPayload : IPacket {

    public byte PacketId => 0x0a;

    public string Channel { get; private set; }
    public byte[] Data { get; private set; }

    public PlayServerCustomPayload(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerCustomPayload(
		string channel,
		byte[] data
		) {
		Channel = channel;
		Data = data;
	}

	public void Serialize(IMinecraftReader reader) {
		Channel = reader.ReadString();
        Data = reader.ReadBuffer();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Channel);
        writer.WriteBuffer(Data);
	}
}