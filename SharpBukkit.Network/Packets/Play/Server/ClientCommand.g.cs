// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerClientCommand : IPacket {

    public byte PacketId => 0x04;

    public int ActionId { get; private set; }

	public PlayServerClientCommand(
		int actionId
		) {
		ActionId = actionId;
	}

	public void Serialize(IMinecraftReader reader) {
		ActionId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(ActionId);
	}
}
