// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWorldBorderWarningDelay : IPacket {

    public byte PacketId => 0x45;

    public int WarningTime { get; private set; }

    public PlayClientWorldBorderWarningDelay(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientWorldBorderWarningDelay(
		int warningTime
		) {
		WarningTime = warningTime;
	}

	public void Serialize(IMinecraftReader reader) {
		WarningTime = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(WarningTime);
	}
}