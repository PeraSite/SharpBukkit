// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Login;

public record LoginClientCompress : IPacket {

    public byte PacketId => 0x03;

    public int Threshold { get; private set; }

	public LoginClientCompress(
		int threshold
		) {
		Threshold = threshold;
	}

	public void Serialize(IMinecraftReader reader) {
		Threshold = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Threshold);
	}
}
