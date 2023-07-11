// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientBlockChange : IPacket {

    public byte PacketId => 0x0c;

    public Vector3 Location { get; private set; }
    public int Type { get; private set; }

	public PlayClientBlockChange(
		Vector3 location,
		int type
		) {
		Location = location;
		Type = type;
	}

	public void Serialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Type = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Type);
	}
}
