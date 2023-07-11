// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerBlockDig : IPacket {

    public byte PacketId => 0x1a;

    public int Status { get; private set; }
    public Vector3 Location { get; private set; }
    public sbyte Face { get; private set; }

    public PlayServerBlockDig(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerBlockDig(
		int status,
		Vector3 location,
		sbyte face
		) {
		Status = status;
		Location = location;
		Face = face;
	}

	public void Deserialize(IMinecraftReader reader) {
		Status = reader.ReadVarInt();
        Location = reader.ReadPosition();
        Face = reader.ReadSByte();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Status);
        writer.WritePosition(Location);
        writer.WriteSByte(Face);
	}
}
