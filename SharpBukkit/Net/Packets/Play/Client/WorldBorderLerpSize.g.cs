// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldBorderLerpSize : IPacket {

    public byte PacketId => 0x43;

    public double OldDiameter { get; private set; }
    public double NewDiameter { get; private set; }
    public long Speed { get; private set; }

    public PlayClientWorldBorderLerpSize(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldBorderLerpSize(
		double oldDiameter,
		double newDiameter,
		long speed
		) {
		OldDiameter = oldDiameter;
		NewDiameter = newDiameter;
		Speed = speed;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(OldDiameter);
        writer.WriteDouble(NewDiameter);
        writer.WriteLong(Speed);
	}

	public void Deserialize(IMinecraftReader reader) {
		OldDiameter = reader.ReadDouble();
        NewDiameter = reader.ReadDouble();
        Speed = reader.ReadLong();
	}
}
