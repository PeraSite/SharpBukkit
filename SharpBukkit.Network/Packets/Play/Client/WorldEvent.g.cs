// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWorldEvent : IPacket {

    public byte PacketId => 0x23;

    public int EffectId { get; private set; }
    public Vector3 Location { get; private set; }
    public int Data { get; private set; }
    public bool Global { get; private set; }

	public PlayClientWorldEvent(
		int effectId,
		Vector3 location,
		int data,
		bool global
		) {
		EffectId = effectId;
		Location = location;
		Data = data;
		Global = global;
	}

	public void Serialize(IMinecraftReader reader) {
		EffectId = reader.ReadInt();
        Location = reader.ReadPosition();
        Data = reader.ReadInt();
        Global = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(EffectId);
        writer.WritePosition(Location);
        writer.WriteInt(Data);
        writer.WriteBool(Global);
	}
}
