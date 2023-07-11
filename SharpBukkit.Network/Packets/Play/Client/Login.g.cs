// Auto-generated
using System.Numerics;
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.API.Models;
using SharpBukkit.Network.Models.Nbt;
using SharpNBT;

namespace SharpBukkit.Packet.Play;

public record PlayClientLogin : IPacket {

    public byte PacketId => 0x26;

    public int EntityId { get; private set; }
    public bool IsHardcore { get; private set; }
    public byte GameMode { get; private set; }
    public sbyte PreviousGameMode { get; private set; }
    public DimensionCodec DimensionCodec { get; private set; }
    public Dimension Dimension { get; private set; }
    public string WorldName { get; private set; }
    public long HashedSeed { get; private set; }
    public int MaxPlayers { get; private set; }
    public int ViewDistance { get; private set; }
    public int SimulationDistance { get; private set; }
    public bool ReducedDebugInfo { get; private set; }
    public bool EnableRespawnScreen { get; private set; }
    public bool IsDebug { get; private set; }
    public bool IsFlat { get; private set; }

    public PlayClientLogin(IMinecraftReader reader) {
	    Serialize(reader);
    }

	public PlayClientLogin(
		int entityId,
		bool isHardcore,
		byte gameMode,
		sbyte previousGameMode,
		DimensionCodec dimensionCodec,
		Dimension dimension,
		string worldName,
		long hashedSeed,
		int maxPlayers,
		int viewDistance,
		int simulationDistance,
		bool reducedDebugInfo,
		bool enableRespawnScreen,
		bool isDebug,
		bool isFlat
		) {
		EntityId = entityId;
		IsHardcore = isHardcore;
		GameMode = gameMode;
		PreviousGameMode = previousGameMode;
		DimensionCodec = dimensionCodec;
		Dimension = dimension;
		WorldName = worldName;
		HashedSeed = hashedSeed;
		MaxPlayers = maxPlayers;
		ViewDistance = viewDistance;
		SimulationDistance = simulationDistance;
		ReducedDebugInfo = reducedDebugInfo;
		EnableRespawnScreen = enableRespawnScreen;
		IsDebug = isDebug;
		IsFlat = isFlat;
	}

	public void Serialize(IMinecraftReader reader) {
		EntityId = reader.ReadInt();
        IsHardcore = reader.ReadBool();
        GameMode = reader.ReadByte();
        PreviousGameMode = reader.ReadSByte();
        DimensionCodec = reader.ReadNbt<DimensionCodec>();
        Dimension = reader.ReadNbt<Dimension>();
        WorldName = reader.ReadString();
        HashedSeed = reader.ReadLong();
        MaxPlayers = reader.ReadVarInt();
        ViewDistance = reader.ReadVarInt();
        SimulationDistance = reader.ReadVarInt();
        ReducedDebugInfo = reader.ReadBool();
        EnableRespawnScreen = reader.ReadBool();
        IsDebug = reader.ReadBool();
        IsFlat = reader.ReadBool();
	}

	public void Deserialize(IMinecraftWriter writer) {
		writer.WriteInt(EntityId);
        writer.WriteBool(IsHardcore);
        writer.WriteByte(GameMode);
        writer.WriteSByte(PreviousGameMode);
        writer.WriteNbt<DimensionCodec>(DimensionCodec);
        writer.WriteNbt<Dimension>(Dimension);
        writer.WriteString(WorldName);
        writer.WriteLong(HashedSeed);
        writer.WriteVarInt(MaxPlayers);
        writer.WriteVarInt(ViewDistance);
        writer.WriteVarInt(SimulationDistance);
        writer.WriteBool(ReducedDebugInfo);
        writer.WriteBool(EnableRespawnScreen);
        writer.WriteBool(IsDebug);
        writer.WriteBool(IsFlat);
	}
}