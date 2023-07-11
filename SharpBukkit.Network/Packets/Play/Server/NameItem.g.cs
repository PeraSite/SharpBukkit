// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayServerNameItem : IPacket {

    public byte PacketId => 0x20;

    public string Name { get; private set; }

	public PlayServerNameItem(
		string name
		) {
		Name = name;
	}

	public void Serialize(IMinecraftReader reader) {
		Name = reader.ReadString();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteString(Name);
	}
}
