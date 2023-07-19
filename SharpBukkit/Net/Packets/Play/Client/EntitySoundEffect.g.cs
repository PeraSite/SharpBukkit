// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientEntitySoundEffect : IPacket {

    public byte PacketId => 0x5c;

    public int SoundId { get; private set; }
    public int SoundCategory { get; private set; }
    public int EntityId { get; private set; }
    public float Volume { get; private set; }
    public float Pitch { get; private set; }

    public PlayClientEntitySoundEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientEntitySoundEffect(
		int soundId,
		int soundCategory,
		int entityId,
		float volume,
		float pitch
		) {
		SoundId = soundId;
		SoundCategory = soundCategory;
		EntityId = entityId;
		Volume = volume;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(SoundId);
        writer.WriteVarInt(SoundCategory);
        writer.WriteVarInt(EntityId);
        writer.WriteFloat(Volume);
        writer.WriteFloat(Pitch);
	}

	public void Deserialize(IMinecraftReader reader) {
		SoundId = reader.ReadVarInt();
        SoundCategory = reader.ReadVarInt();
        EntityId = reader.ReadVarInt();
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}
}
