// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientUpdateHealth : IPacket {

    public byte PacketId => 0x52;

    public float Health { get; private set; }
    public int Food { get; private set; }
    public float FoodSaturation { get; private set; }

	public PlayClientUpdateHealth(
		float health,
		int food,
		float foodSaturation
		) {
		Health = health;
		Food = food;
		FoodSaturation = foodSaturation;
	}

	public void Serialize(IMinecraftReader reader) {
		Health = reader.ReadFloat();
        Food = reader.ReadVarInt();
        FoodSaturation = reader.ReadFloat();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteFloat(Health);
        writer.WriteVarInt(Food);
        writer.WriteFloat(FoodSaturation);
	}
}