// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntityEffect : IPacket {

    public byte PacketId => 0x65;

    public int EntityId { get; private set; }
    public int EffectId { get; private set; }
    public sbyte Amplifier { get; private set; }
    public int Duration { get; private set; }
    public sbyte HideParticles { get; private set; }

    public PlayClientEntityEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntityEffect(
		int entityId,
		int effectId,
		sbyte amplifier,
		int duration,
		sbyte hideParticles
		) {
		EntityId = entityId;
		EffectId = effectId;
		Amplifier = amplifier;
		Duration = duration;
		HideParticles = hideParticles;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(EntityId);
        writer.WriteVarInt(EffectId);
        writer.WriteSByte(Amplifier);
        writer.WriteVarInt(Duration);
        writer.WriteSByte(HideParticles);
	}

	public void Deserialize(IMinecraftReader reader) {
		EntityId = reader.ReadVarInt();
        EffectId = reader.ReadVarInt();
        Amplifier = reader.ReadSByte();
        Duration = reader.ReadVarInt();
        HideParticles = reader.ReadSByte();
	}
}
