// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSetBeaconEffect : IPacket {

    public byte PacketId => 0x24;

    public int PrimaryEffect { get; private set; }
    public int SecondaryEffect { get; private set; }

    public PlayServerSetBeaconEffect(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSetBeaconEffect(
		int primaryEffect,
		int secondaryEffect
		) {
		PrimaryEffect = primaryEffect;
		SecondaryEffect = secondaryEffect;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(PrimaryEffect);
        writer.WriteVarInt(SecondaryEffect);
	}

	public void Deserialize(IMinecraftReader reader) {
		PrimaryEffect = reader.ReadVarInt();
        SecondaryEffect = reader.ReadVarInt();
	}
}
