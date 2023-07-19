// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientSetTitleTime : IPacket {

    public byte PacketId => 0x5b;

    public int FadeIn { get; private set; }
    public int Stay { get; private set; }
    public int FadeOut { get; private set; }

    public PlayClientSetTitleTime(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSetTitleTime(
		int fadeIn,
		int stay,
		int fadeOut
		) {
		FadeIn = fadeIn;
		Stay = stay;
		FadeOut = fadeOut;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(FadeIn);
        writer.WriteInt(Stay);
        writer.WriteInt(FadeOut);
	}

	public void Deserialize(IMinecraftReader reader) {
		FadeIn = reader.ReadInt();
        Stay = reader.ReadInt();
        FadeOut = reader.ReadInt();
	}
}
