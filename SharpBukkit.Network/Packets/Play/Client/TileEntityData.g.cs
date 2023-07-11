// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientTileEntityData : IPacket {

    public byte PacketId => 0x0a;

    public Vector3 Location { get; private set; }
    public int Action { get; private set; }
    public CompoundTag? NbtData { get; private set; }

    public PlayClientTileEntityData(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientTileEntityData(
		Vector3 location,
		int action,
		CompoundTag? nbtData
		) {
		Location = location;
		Action = action;
		NbtData = nbtData;
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
        Action = reader.ReadVarInt();
        NbtData = reader.ReadOptNbtTag();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
        writer.WriteVarInt(Action);
        writer.WriteOptNbtTag(NbtData);
	}
}
