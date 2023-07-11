// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerQueryBlockNbt : IPacket {

    public byte PacketId => 0x01;

    public int TransactionId { get; private set; }
    public Vector3 Location { get; private set; }

	public PlayServerQueryBlockNbt(
		int transactionId,
		Vector3 location
		) {
		TransactionId = transactionId;
		Location = location;
	}

	public void Serialize(IMinecraftReader reader) {
		TransactionId = reader.ReadVarInt();
        Location = reader.ReadPosition();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(TransactionId);
        writer.WritePosition(Location);
	}
}
