// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerCustomPayload : IPacket {

    public byte PacketId => 0x0a;

    public string Channel { get; private set; }
    public byte[] Data { get; private set; }

    public PlayServerCustomPayload(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerCustomPayload(
		string channel,
		byte[] data
		) {
		Channel = channel;
		Data = data;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Channel);
        writer.WriteBuffer(Data);
	}

	public void Deserialize(IMinecraftReader reader) {
		Channel = reader.ReadString();
        Data = reader.ReadBuffer();
	}
}
