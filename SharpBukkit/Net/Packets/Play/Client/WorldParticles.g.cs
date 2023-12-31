// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientWorldParticles : IPacket {

    public byte PacketId => 0x24;

    public int ParticleId { get; private set; }
    public bool LongDistance { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public float OffsetX { get; private set; }
    public float OffsetY { get; private set; }
    public float OffsetZ { get; private set; }
    public float ParticleData { get; private set; }
    public int Particles { get; private set; }

    public PlayClientWorldParticles(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientWorldParticles(
		int particleId,
		bool longDistance,
		double x,
		double y,
		double z,
		float offsetX,
		float offsetY,
		float offsetZ,
		float particleData,
		int particles
		) {
		ParticleId = particleId;
		LongDistance = longDistance;
		X = x;
		Y = y;
		Z = z;
		OffsetX = offsetX;
		OffsetY = offsetY;
		OffsetZ = offsetZ;
		ParticleData = particleData;
		Particles = particles;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteInt(ParticleId);
        writer.WriteBool(LongDistance);
        writer.WriteDouble(X);
        writer.WriteDouble(Y);
        writer.WriteDouble(Z);
        writer.WriteFloat(OffsetX);
        writer.WriteFloat(OffsetY);
        writer.WriteFloat(OffsetZ);
        writer.WriteFloat(ParticleData);
        writer.WriteInt(Particles);
	}

	public void Deserialize(IMinecraftReader reader) {
		ParticleId = reader.ReadInt();
        LongDistance = reader.ReadBool();
        X = reader.ReadDouble();
        Y = reader.ReadDouble();
        Z = reader.ReadDouble();
        OffsetX = reader.ReadFloat();
        OffsetY = reader.ReadFloat();
        OffsetZ = reader.ReadFloat();
        ParticleData = reader.ReadFloat();
        Particles = reader.ReadInt();
	}
}
