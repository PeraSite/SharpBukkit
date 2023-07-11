// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCustomPayload : IPacket {

    public byte PacketId => 0x18;

    public string Channel { get; private set; }
    public byte[] Data { get; private set; }

    public PlayClientCustomPayload(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientCustomPayload(
		string channel,
		byte[] data
		) {
		Channel = channel;
		Data = data;
	}

	public void Deserialize(IMinecraftReader reader) {
		Channel = reader.ReadString();
        Data = reader.ReadBuffer();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Channel);
        writer.WriteBuffer(Data);
	}
}
