// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSteerBoat : IPacket {

    public byte PacketId => 0x16;

    public bool LeftPaddle { get; private set; }
    public bool RightPaddle { get; private set; }

    public PlayServerSteerBoat(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerSteerBoat(
		bool leftPaddle,
		bool rightPaddle
		) {
		LeftPaddle = leftPaddle;
		RightPaddle = rightPaddle;
	}

	public void Serialize(IMinecraftReader reader) {
		LeftPaddle = reader.ReadBool();
        RightPaddle = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteBool(LeftPaddle);
        writer.WriteBool(RightPaddle);
	}
}