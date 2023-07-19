// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSettings : IPacket {

    public byte PacketId => 0x05;

    public string Locale { get; private set; }
    public sbyte ViewDistance { get; private set; }
    public int ChatFlags { get; private set; }
    public bool ChatColors { get; private set; }
    public byte SkinParts { get; private set; }
    public int MainHand { get; private set; }
    public bool EnableTextFiltering { get; private set; }
    public bool EnableServerListing { get; private set; }

    public PlayServerSettings(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSettings(
		string locale,
		sbyte viewDistance,
		int chatFlags,
		bool chatColors,
		byte skinParts,
		int mainHand,
		bool enableTextFiltering,
		bool enableServerListing
		) {
		Locale = locale;
		ViewDistance = viewDistance;
		ChatFlags = chatFlags;
		ChatColors = chatColors;
		SkinParts = skinParts;
		MainHand = mainHand;
		EnableTextFiltering = enableTextFiltering;
		EnableServerListing = enableServerListing;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Locale);
        writer.WriteSByte(ViewDistance);
        writer.WriteVarInt(ChatFlags);
        writer.WriteBool(ChatColors);
        writer.WriteByte(SkinParts);
        writer.WriteVarInt(MainHand);
        writer.WriteBool(EnableTextFiltering);
        writer.WriteBool(EnableServerListing);
	}

	public void Deserialize(IMinecraftReader reader) {
		Locale = reader.ReadString();
        ViewDistance = reader.ReadSByte();
        ChatFlags = reader.ReadVarInt();
        ChatColors = reader.ReadBool();
        SkinParts = reader.ReadByte();
        MainHand = reader.ReadVarInt();
        EnableTextFiltering = reader.ReadBool();
        EnableServerListing = reader.ReadBool();
	}
}
