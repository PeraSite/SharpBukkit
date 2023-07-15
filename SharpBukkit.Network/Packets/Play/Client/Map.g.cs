// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientMap : IPacket {

    public byte PacketId => 0x27;

    public int ItemDamage { get; private set; }
    public sbyte Scale { get; private set; }
    public bool Locked { get; private set; }
    public byte Columns { get; private set; }

    public PlayClientMap(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientMap(
		int itemDamage,
		sbyte scale,
		bool locked,
		byte columns
		) {
		ItemDamage = itemDamage;
		Scale = scale;
		Locked = locked;
		Columns = columns;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ItemDamage);
        writer.WriteSByte(Scale);
        writer.WriteBool(Locked);
        writer.WriteByte(Columns);
	}

	public void Deserialize(IMinecraftReader reader) {
		ItemDamage = reader.ReadVarInt();
        Scale = reader.ReadSByte();
        Locked = reader.ReadBool();
        Columns = reader.ReadByte();
	}
}