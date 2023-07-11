// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientGameStateChange : IPacket {

    public byte PacketId => 0x1e;

    public byte Reason { get; private set; }
    public float GameMode { get; private set; }

	public PlayClientGameStateChange(
		byte reason,
		float gameMode
		) {
		Reason = reason;
		GameMode = gameMode;
	}

	public void Serialize(IMinecraftReader reader) {
		Reason = reader.ReadByte();
        GameMode = reader.ReadFloat();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteByte(Reason);
        writer.WriteFloat(GameMode);
	}
}