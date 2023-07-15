// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientAdvancements : IPacket {

    public byte PacketId => 0x63;

    public bool Reset { get; private set; }
    public string[] Identifiers { get; private set; }

    public PlayClientAdvancements(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientAdvancements(
		bool reset,
		string[] identifiers
		) {
		Reset = reset;
		Identifiers = identifiers;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteBool(Reset);
        writer.WriteStringArray(Identifiers);
	}

	public void Deserialize(IMinecraftReader reader) {
		Reset = reader.ReadBool();
        Identifiers = reader.ReadStringArray();
	}
}