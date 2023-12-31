// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientNamedSoundEffect : IPacket {

    public byte PacketId => 0x19;

    public string SoundName { get; private set; }
    public int SoundCategory { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }
    public float Volume { get; private set; }
    public float Pitch { get; private set; }

    public PlayClientNamedSoundEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientNamedSoundEffect(
		string soundName,
		int soundCategory,
		int x,
		int y,
		int z,
		float volume,
		float pitch
		) {
		SoundName = soundName;
		SoundCategory = soundCategory;
		X = x;
		Y = y;
		Z = z;
		Volume = volume;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(SoundName);
        writer.WriteVarInt(SoundCategory);
        writer.WriteInt(X);
        writer.WriteInt(Y);
        writer.WriteInt(Z);
        writer.WriteFloat(Volume);
        writer.WriteFloat(Pitch);
	}

	public void Deserialize(IMinecraftReader reader) {
		SoundName = reader.ReadString();
        SoundCategory = reader.ReadVarInt();
        X = reader.ReadInt();
        Y = reader.ReadInt();
        Z = reader.ReadInt();
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}
}
