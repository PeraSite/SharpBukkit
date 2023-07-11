// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientAcknowledgePlayerDigging : IPacket {

    public byte PacketId => 0x08;

    public Vector3 Location { get; private set; }
    public int Block { get; private set; }
    public int Status { get; private set; }
    public bool Successful { get; private set; }

    public PlayClientAcknowledgePlayerDigging(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientAcknowledgePlayerDigging(
		Vector3 location,
		int block,
		int status,
		bool successful
		) {
		Location = location;
		Block = block;
		Status = status;
		Successful = successful;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Block = reader.ReadVarInt();
        Status = reader.ReadVarInt();
        Successful = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Block);
        writer.WriteVarInt(Status);
        writer.WriteBool(Successful);
	}
}