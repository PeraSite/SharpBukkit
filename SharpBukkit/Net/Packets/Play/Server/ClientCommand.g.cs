// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerClientCommand : IPacket {

    public byte PacketId => 0x04;

    public int ActionId { get; private set; }

    public PlayServerClientCommand(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerClientCommand(
		int actionId
		) {
		ActionId = actionId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ActionId);
	}

	public void Deserialize(IMinecraftReader reader) {
		ActionId = reader.ReadVarInt();
	}
}
