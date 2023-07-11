// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSetBeaconEffect : IPacket {

    public byte PacketId => 0x24;

    public int PrimaryEffect { get; private set; }
    public int SecondaryEffect { get; private set; }

    public PlayServerSetBeaconEffect(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerSetBeaconEffect(
		int primaryEffect,
		int secondaryEffect
		) {
		PrimaryEffect = primaryEffect;
		SecondaryEffect = secondaryEffect;
	}

	public void Serialize(IMinecraftReader reader) {
		PrimaryEffect = reader.ReadVarInt();
        SecondaryEffect = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(PrimaryEffect);
        writer.WriteVarInt(SecondaryEffect);
	}
}