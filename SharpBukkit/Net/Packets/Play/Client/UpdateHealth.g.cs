// Auto-generated
using System;
using System.Numerics;
using SharpBukkit.Net.Models;
using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;
using SharpNBT;

namespace SharpBukkit.Net.Packets;

public record PlayClientUpdateHealth : IPacket {

    public byte PacketId => 0x52;

    public float Health { get; private set; }
    public int Food { get; private set; }
    public float FoodSaturation { get; private set; }

    public PlayClientUpdateHealth(IMinecraftReader reader) {
	    Deserialize(reader);
    }

	public PlayClientUpdateHealth(
		float health,
		int food,
		float foodSaturation
		) {
		Health = health;
		Food = food;
		FoodSaturation = foodSaturation;
	}

	public void Serialize(IMinecraftWriter writer) {
		writer.WriteFloat(Health);
        writer.WriteVarInt(Food);
        writer.WriteFloat(FoodSaturation);
	}

	public void Deserialize(IMinecraftReader reader) {
		Health = reader.ReadFloat();
        Food = reader.ReadVarInt();
        FoodSaturation = reader.ReadFloat();
	}
}
