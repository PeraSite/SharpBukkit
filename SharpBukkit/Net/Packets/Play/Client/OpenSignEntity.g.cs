// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientOpenSignEntity : IPacket {

    public byte PacketId => 0x2f;

    public Vector3 Location { get; private set; }

    public PlayClientOpenSignEntity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientOpenSignEntity(
		Vector3 location
		) {
		Location = location;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(Location);
	}

	public void Deserialize(IMinecraftReader reader) {
		Location = reader.ReadPosition();
	}
}
