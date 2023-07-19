// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientCamera : IPacket {

    public byte PacketId => 0x47;

    public int CameraId { get; private set; }

    public PlayClientCamera(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientCamera(
		int cameraId
		) {
		CameraId = cameraId;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(CameraId);
	}

	public void Deserialize(IMinecraftReader reader) {
		CameraId = reader.ReadVarInt();
	}
}
