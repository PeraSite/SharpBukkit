// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientDeclareCommands : IPacket {

    public byte PacketId => 0x12;

    public int RootIndex { get; private set; }

    public PlayClientDeclareCommands(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientDeclareCommands(
		int rootIndex
		) {
		RootIndex = rootIndex;
	}

	public void Serialize(IMinecraftReader reader) {
		RootIndex = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(RootIndex);
	}
}