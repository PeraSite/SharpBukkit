// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSoundEffect : IPacket {

    public byte PacketId => 0x5d;

    public int SoundId { get; private set; }
    public int SoundCategory { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }
    public float Volume { get; private set; }
    public float Pitch { get; private set; }

    public PlayClientSoundEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSoundEffect(
		int soundId,
		int soundCategory,
		int x,
		int y,
		int z,
		float volume,
		float pitch
		) {
		SoundId = soundId;
		SoundCategory = soundCategory;
		X = x;
		Y = y;
		Z = z;
		Volume = volume;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(SoundId);
        writer.WriteVarInt(SoundCategory);
        writer.WriteInt(X);
        writer.WriteInt(Y);
        writer.WriteInt(Z);
        writer.WriteFloat(Volume);
        writer.WriteFloat(Pitch);
	}

	public void Deserialize(IMinecraftReader reader) {
		SoundId = reader.ReadVarInt();
        SoundCategory = reader.ReadVarInt();
        X = reader.ReadInt();
        Y = reader.ReadInt();
        Z = reader.ReadInt();
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}
}
