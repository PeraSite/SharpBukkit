// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientSculkVibrationSignal : IPacket {

    public byte PacketId => 0x05;

    public Vector3 SourcePosition { get; private set; }
    public string DestinationIdentifier { get; private set; }
    public int ArrivalTicks { get; private set; }

    public PlayClientSculkVibrationSignal(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientSculkVibrationSignal(
		Vector3 sourcePosition,
		string destinationIdentifier,
		int arrivalTicks
		) {
		SourcePosition = sourcePosition;
		DestinationIdentifier = destinationIdentifier;
		ArrivalTicks = arrivalTicks;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WritePosition(SourcePosition);
        writer.WriteString(DestinationIdentifier);
        writer.WriteVarInt(ArrivalTicks);
	}

	public void Deserialize(IMinecraftReader reader) {
		SourcePosition = reader.ReadPosition();
        DestinationIdentifier = reader.ReadString();
        ArrivalTicks = reader.ReadVarInt();
	}
}