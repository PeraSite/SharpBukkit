// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerResourcePackReceive : IPacket {

    public byte PacketId => 0x21;

    public int Result { get; private set; }

    public PlayServerResourcePackReceive(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerResourcePackReceive(
		int result
		) {
		Result = result;
	}

	public void Serialize(IMinecraftReader reader) {
		Result = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(Result);
	}
}