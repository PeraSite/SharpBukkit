// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerPong : IPacket {

    public byte PacketId => 0x1d;

    public int Id { get; private set; }

    public PlayServerPong(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerPong(
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
