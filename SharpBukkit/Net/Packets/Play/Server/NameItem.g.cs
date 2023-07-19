// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerNameItem : IPacket {

    public byte PacketId => 0x20;

    public string Name { get; private set; }

    public PlayServerNameItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerNameItem(
		string name
		) {
		Name = name;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Name);
	}

	public void Deserialize(IMinecraftReader reader) {
		Name = reader.ReadString();
	}
}
