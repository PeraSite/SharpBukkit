// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

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

	public void Deserialize(IMinecraftReader reader) {
		CameraId = reader.ReadVarInt();
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteVarInt(CameraId);
	}
}
