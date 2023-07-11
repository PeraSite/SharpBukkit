// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientEntitySoundEffect : IPacket {

    public byte PacketId => 0x5c;

    public int SoundId { get; private set; }
    public int SoundCategory { get; private set; }
    public int EntityId { get; private set; }
    public float Volume { get; private set; }
    public float Pitch { get; private set; }

	public PlayClientEntitySoundEffect(
		int soundId,
		int soundCategory,
		int entityId,
		float volume,
		float pitch
		) {
		SoundId = soundId;
		SoundCategory = soundCategory;
		EntityId = entityId;
		Volume = volume;
		Pitch = pitch;
	}

	public void Serialize(IMinecraftReader reader) {
		SoundId = reader.ReadVarInt();
        SoundCategory = reader.ReadVarInt();
        EntityId = reader.ReadVarInt();
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteVarInt(SoundId);
        writer.WriteVarInt(SoundCategory);
        writer.WriteVarInt(EntityId);
        writer.WriteFloat(Volume);
        writer.WriteFloat(Pitch);
	}
}
