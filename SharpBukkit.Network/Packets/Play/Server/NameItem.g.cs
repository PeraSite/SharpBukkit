// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerNameItem : IPacket {

    public byte PacketId => 0x20;

    public string Name { get; private set; }

    public PlayServerNameItem(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayServerNameItem(
		string name
		) {
		Name = name;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteString(Name);
	}

	public void Deserialize(IMinecraftReader reader) {
		Name = reader.ReadString();
	}
}