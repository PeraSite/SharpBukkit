// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSpawnEntityPainting : IPacket {

    public byte PacketId => 0x03;

    public int EntityId { get; private set; }
    public Guid EntityUUID { get; private set; }
    public int Title { get; private set; }
    public Vector3 Location { get; private set; }
    public byte Direction { get; private set; }

    public PlayClientSpawnEntityPainting(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientSpawnEntityPainting(
		int entityId,
		Guid entityUUID,
		int title,
		Vector3 location,
		byte direction
		) {
		EntityId = entityId;
		EntityUUID = entityUUID;
		Title = title;
		Location = location;
		Direction = direction;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        EntityUUID = reader.ReadUuid();
        Title = reader.ReadVarInt();
        Location = reader.ReadPosition();
        Direction = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteUuid(EntityUUID);
        writer.WriteVarInt(Title);
        writer.WritePosition(Location);
        writer.WriteByte(Direction);
	}
}