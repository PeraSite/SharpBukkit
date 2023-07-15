// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerUpdateCommandBlockMinecart : IPacket {

    public byte PacketId => 0x27;

    public int EntityId { get; private set; }
    public string Command { get; private set; }
    public bool TrackOutput { get; private set; }

    public PlayServerUpdateCommandBlockMinecart(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUpdateCommandBlockMinecart(
		int entityId,
		string command,
		bool trackOutput
		) {
		EntityId = entityId;
		Command = command;
		TrackOutput = trackOutput;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteString(Command);
        writer.WriteBool(TrackOutput);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        Command = reader.ReadString();
        TrackOutput = reader.ReadBool();
	}
}