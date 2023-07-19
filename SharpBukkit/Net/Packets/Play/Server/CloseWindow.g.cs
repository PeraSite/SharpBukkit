// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerCloseWindow : IPacket {

    public byte PacketId => 0x09;

    public byte WindowId { get; private set; }

    public PlayServerCloseWindow(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerCloseWindow(
		byte windowId
		) {
		WindowId = windowId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteByte(WindowId);
	}

	public void Deserialize(IMinecraftReader reader) {
		WindowId = reader.ReadByte();
	}
}
