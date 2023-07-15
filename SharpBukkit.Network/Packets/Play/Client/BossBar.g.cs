// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientBossBar : IPacket {

    public byte PacketId => 0x0d;

    public Guid EntityUUID { get; private set; }
    public int Action { get; private set; }

    public PlayClientBossBar(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientBossBar(
		Guid entityUUID,
		int action
		) {
		EntityUUID = entityUUID;
		Action = action;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteUuid(EntityUUID);
        writer.WriteVarInt(Action);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityUUID = reader.ReadUuid();
        Action = reader.ReadVarInt();
	}
}