// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientChat : IPacket {

    public byte PacketId => 0x0f;

    public string Message { get; private set; }
    public sbyte Position { get; private set; }
    public Guid Sender { get; private set; }

    public PlayClientChat(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientChat(
		string message,
		sbyte position,
		Guid sender
		) {
		Message = message;
		Position = position;
		Sender = sender;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Message);
        writer.WriteSByte(Position);
        writer.WriteUuid(Sender);
	}

	public void Deserialize(IMinecraftReader reader) {
		Message = reader.ReadString();
        Position = reader.ReadSByte();
        Sender = reader.ReadUuid();
	}
}
