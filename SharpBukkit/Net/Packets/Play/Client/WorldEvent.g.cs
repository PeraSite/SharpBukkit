// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldEvent : IPacket {

    public byte PacketId => 0x23;

    public int EffectId { get; private set; }
    public Vector3 Location { get; private set; }
    public int Data { get; private set; }
    public bool Global { get; private set; }

    public PlayClientWorldEvent(IMinecraftReader reader) {
	    Deserialize(reader);
    }

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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(EffectId);
        writer.WritePosition(Location);
        writer.WriteInt(Data);
        writer.WriteBool(Global);
	}

	public void Deserialize(IMinecraftReader reader) {
		EffectId = reader.ReadInt();
        Location = reader.ReadPosition();
        Data = reader.ReadInt();
        Global = reader.ReadBool();
	}
}
