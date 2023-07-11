// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientChat : IPacket {

    public byte PacketId => 0x0f;

    public string Message { get; private set; }
    public sbyte Position { get; private set; }
    public Guid Sender { get; private set; }

    public PlayClientChat(IMinecraftReader reader) {
	    Serialize(reader);
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

	public void Serialize(IMinecraftReader reader) {
		Message = reader.ReadString();
        Position = reader.ReadSByte();
        Sender = reader.ReadUuid();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Message);
        writer.WriteSByte(Position);
        writer.WriteUuid(Sender);
	}
}