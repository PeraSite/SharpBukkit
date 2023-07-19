// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientDeclareCommands : IPacket {

    public byte PacketId => 0x12;

    public int RootIndex { get; private set; }

    public PlayClientDeclareCommands(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientDeclareCommands(
		int rootIndex
		) {
		RootIndex = rootIndex;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(RootIndex);
	}

	public void Deserialize(IMinecraftReader reader) {
		RootIndex = reader.ReadVarInt();
	}
}
