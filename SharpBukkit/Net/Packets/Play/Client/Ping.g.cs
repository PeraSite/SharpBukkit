// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientPing : IPacket {

    public byte PacketId => 0x30;

    public int Id { get; private set; }

    public PlayClientPing(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientPing(
		int id
		) {
		Id = id;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(Id);
	}

	public void Deserialize(IMinecraftReader reader) {
		Id = reader.ReadInt();
	}
}
