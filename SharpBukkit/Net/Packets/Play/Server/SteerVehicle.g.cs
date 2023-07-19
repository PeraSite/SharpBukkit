// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayServerSteerVehicle : IPacket {

    public byte PacketId => 0x1c;

    public float Sideways { get; private set; }
    public float Forward { get; private set; }
    public byte Jump { get; private set; }

    public PlayServerSteerVehicle(IMinecraftReader reader) {
	    Deserialize(reader);
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

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteFloat(Sideways);
        writer.WriteFloat(Forward);
        writer.WriteByte(Jump);
	}

	public void Deserialize(IMinecraftReader reader) {
		Sideways = reader.ReadFloat();
        Forward = reader.ReadFloat();
        Jump = reader.ReadByte();
	}
}
