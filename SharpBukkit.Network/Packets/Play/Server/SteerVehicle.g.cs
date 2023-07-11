// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerSteerVehicle : IPacket {

    public byte PacketId => 0x1c;

    public float Sideways { get; private set; }
    public float Forward { get; private set; }
    public byte Jump { get; private set; }

    public PlayServerSteerVehicle(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayServerSteerVehicle(
		float sideways,
		float forward,
		byte jump
		) {
		Sideways = sideways;
		Forward = forward;
		Jump = jump;
	}

	public void Serialize(IMinecraftReader reader) {
		Sideways = reader.ReadFloat();
        Forward = reader.ReadFloat();
        Jump = reader.ReadByte();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteFloat(Sideways);
        writer.WriteFloat(Forward);
        writer.WriteByte(Jump);
	}
}