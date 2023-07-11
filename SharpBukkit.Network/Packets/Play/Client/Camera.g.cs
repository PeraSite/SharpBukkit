// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientCamera : IPacket {

    public byte PacketId => 0x47;

    public int CameraId { get; private set; }

	public PlayClientCamera(
		int cameraId
		) {
		CameraId = cameraId;
	}

	public void Serialize(IMinecraftReader reader) {
		CameraId = reader.ReadVarInt();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(CameraId);
	}
}
