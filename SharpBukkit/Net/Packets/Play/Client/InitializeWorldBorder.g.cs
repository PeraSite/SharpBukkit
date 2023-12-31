// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientInitializeWorldBorder : IPacket {

    public byte PacketId => 0x20;

    public double X { get; private set; }
    public double Z { get; private set; }
    public double OldDiameter { get; private set; }
    public double NewDiameter { get; private set; }
    public long Speed { get; private set; }
    public int PortalTeleportBoundary { get; private set; }
    public int WarningBlocks { get; private set; }
    public int WarningTime { get; private set; }

    public PlayClientInitializeWorldBorder(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientInitializeWorldBorder(
		double x,
		double z,
		double oldDiameter,
		double newDiameter,
		long speed,
		int portalTeleportBoundary,
		int warningBlocks,
		int warningTime
		) {
		X = x;
		Z = z;
		OldDiameter = oldDiameter;
		NewDiameter = newDiameter;
		Speed = speed;
		PortalTeleportBoundary = portalTeleportBoundary;
		WarningBlocks = warningBlocks;
		WarningTime = warningTime;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteDouble(X);
        writer.WriteDouble(Z);
        writer.WriteDouble(OldDiameter);
        writer.WriteDouble(NewDiameter);
        writer.WriteLong(Speed);
        writer.WriteVarInt(PortalTeleportBoundary);
        writer.WriteVarInt(WarningBlocks);
        writer.WriteVarInt(WarningTime);
	}

	public void Deserialize(IMinecraftReader reader) {
		X = reader.ReadDouble();
        Z = reader.ReadDouble();
        OldDiameter = reader.ReadDouble();
        NewDiameter = reader.ReadDouble();
        Speed = reader.ReadLong();
        PortalTeleportBoundary = reader.ReadVarInt();
        WarningBlocks = reader.ReadVarInt();
        WarningTime = reader.ReadVarInt();
	}
}
