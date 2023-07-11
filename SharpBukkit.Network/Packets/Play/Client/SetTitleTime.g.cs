// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSetTitleTime : IPacket {

    public byte PacketId => 0x5b;

    public int FadeIn { get; private set; }
    public int Stay { get; private set; }
    public int FadeOut { get; private set; }

    public PlayClientSetTitleTime(IMinecraftReader reader) {
	    Serialize(reader);
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

	public void Serialize(IMinecraftReader reader) {
		FadeIn = reader.ReadInt();
        Stay = reader.ReadInt();
        FadeOut = reader.ReadInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(FadeIn);
        writer.WriteInt(Stay);
        writer.WriteInt(FadeOut);
	}
}