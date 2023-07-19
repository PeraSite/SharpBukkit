// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerUseEntity : IPacket {

    public byte PacketId => 0x0d;

    public int Target { get; private set; }
    public int Mouse { get; private set; }
    public bool Sneaking { get; private set; }

    public PlayServerUseEntity(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerUseEntity(
		int target,
		int mouse,
		bool sneaking
		) {
		Target = target;
		Mouse = mouse;
		Sneaking = sneaking;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Target);
        writer.WriteVarInt(Mouse);
        writer.WriteBool(Sneaking);
	}

	public void Deserialize(IMinecraftReader reader) {
		Target = reader.ReadVarInt();
        Mouse = reader.ReadVarInt();
        Sneaking = reader.ReadBool();
	}
}
