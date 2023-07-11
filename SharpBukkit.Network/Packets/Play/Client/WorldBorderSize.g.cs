// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientWorldBorderSize : IPacket {

    public byte PacketId => 0x44;

    public double Diameter { get; private set; }

    public PlayClientWorldBorderSize(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientWorldBorderSize(
		double diameter
		) {
		Diameter = diameter;
	}

	public void Serialize(IMinecraftReader reader) {
		Diameter = reader.ReadDouble();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteDouble(Diameter);
	}
}