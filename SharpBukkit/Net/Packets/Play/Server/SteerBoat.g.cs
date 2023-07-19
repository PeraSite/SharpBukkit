// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSteerBoat : IPacket {

    public byte PacketId => 0x16;

    public bool LeftPaddle { get; private set; }
    public bool RightPaddle { get; private set; }

    public PlayServerSteerBoat(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerSteerBoat(
		bool leftPaddle,
		bool rightPaddle
		) {
		LeftPaddle = leftPaddle;
		RightPaddle = rightPaddle;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(LeftPaddle);
        writer.WriteBool(RightPaddle);
	}

	public void Deserialize(IMinecraftReader reader) {
		LeftPaddle = reader.ReadBool();
        RightPaddle = reader.ReadBool();
	}
}
