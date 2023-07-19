// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientCloseWindow : IPacket {

    public byte PacketId => 0x13;

    public byte WindowId { get; private set; }

    public PlayClientCloseWindow(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientCloseWindow(
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
