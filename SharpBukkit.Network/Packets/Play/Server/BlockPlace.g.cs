// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerBlockPlace : IPacket {

    public byte PacketId => 0x2e;

    public int Hand { get; private set; }
    public Vector3 Location { get; private set; }
    public int Direction { get; private set; }
    public float CursorX { get; private set; }
    public float CursorY { get; private set; }
    public float CursorZ { get; private set; }
    public bool InsideBlock { get; private set; }

    public PlayServerBlockPlace(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerBlockPlace(
		int hand,
		Vector3 location,
		int direction,
		float cursorX,
		float cursorY,
		float cursorZ,
		bool insideBlock
		) {
		Hand = hand;
		Location = location;
		Direction = direction;
		CursorX = cursorX;
		CursorY = cursorY;
		CursorZ = cursorZ;
		InsideBlock = insideBlock;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Hand);
        writer.WritePosition(Location);
        writer.WriteVarInt(Direction);
        writer.WriteFloat(CursorX);
        writer.WriteFloat(CursorY);
        writer.WriteFloat(CursorZ);
        writer.WriteBool(InsideBlock);
	}

	public void Deserialize(IMinecraftReader reader) {
		Hand = reader.ReadVarInt();
        Location = reader.ReadPosition();
        Direction = reader.ReadVarInt();
        CursorX = reader.ReadFloat();
        CursorY = reader.ReadFloat();
        CursorZ = reader.ReadFloat();
        InsideBlock = reader.ReadBool();
	}
}