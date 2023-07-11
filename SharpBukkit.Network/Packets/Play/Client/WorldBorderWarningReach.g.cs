// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWorldBorderWarningReach : IPacket {

    public byte PacketId => 0x46;

    public int WarningBlocks { get; private set; }

	public PlayClientWorldBorderWarningReach(
		int warningBlocks
		) {
		WarningBlocks = warningBlocks;
	}

	public void Serialize(IMinecraftReader reader) {
		WarningBlocks = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WarningBlocks);
	}
}
