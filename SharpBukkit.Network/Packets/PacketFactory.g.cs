// Auto-generated
using SharpBukkit.Network.API;
using SharpBukkit.Network.API.Stream;
using SharpBukkit.Network.Models;
using SharpBukkit.Packet.Handshaking;
using SharpBukkit.Packet.Login;
using SharpBukkit.Packet.Play;
using SharpBukkit.Packet.Status;

namespace SharpBukkit.Network.Packets;

public static class PacketFactory {
	private static readonly Dictionary<(ConnectionState state, byte id), Func<IMinecraftReader, IPacket>> _factory;

	static PacketFactory() {
		_factory = new Dictionary<(ConnectionState state, byte id), Func<IMinecraftReader, IPacket>>();
	}

	public static void Load() {
		Register(ConnectionState.Handshaking, 0x00, (reader) => new HandshakingServerSetProtocol(reader));
        Register(ConnectionState.Handshaking, 0xfe, (reader) => new HandshakingServerLegacyServerListPing(reader));
        Register(ConnectionState.Status, 0x00, (reader) => new StatusClientServerInfo(reader));
        Register(ConnectionState.Status, 0x01, (reader) => new StatusClientPing(reader));
        Register(ConnectionState.Status, 0x00, (reader) => new StatusServerPingStart(reader));
        Register(ConnectionState.Status, 0x01, (reader) => new StatusServerPing(reader));
        Register(ConnectionState.Login, 0x00, (reader) => new LoginClientDisconnect(reader));
        Register(ConnectionState.Login, 0x01, (reader) => new LoginClientEncryptionBegin(reader));
        Register(ConnectionState.Login, 0x02, (reader) => new LoginClientSuccess(reader));
        Register(ConnectionState.Login, 0x03, (reader) => new LoginClientCompress(reader));
        Register(ConnectionState.Login, 0x04, (reader) => new LoginClientLoginPluginRequest(reader));
        Register(ConnectionState.Login, 0x00, (reader) => new LoginServerLoginStart(reader));
        Register(ConnectionState.Login, 0x01, (reader) => new LoginServerEncryptionBegin(reader));
        Register(ConnectionState.Login, 0x02, (reader) => new LoginServerLoginPluginResponse(reader));
        Register(ConnectionState.Play, 0x00, (reader) => new PlayClientSpawnEntity(reader));
        Register(ConnectionState.Play, 0x01, (reader) => new PlayClientSpawnEntityExperienceOrb(reader));
        Register(ConnectionState.Play, 0x02, (reader) => new PlayClientSpawnEntityLiving(reader));
        Register(ConnectionState.Play, 0x03, (reader) => new PlayClientSpawnEntityPainting(reader));
        Register(ConnectionState.Play, 0x04, (reader) => new PlayClientNamedEntitySpawn(reader));
        Register(ConnectionState.Play, 0x06, (reader) => new PlayClientAnimation(reader));
        Register(ConnectionState.Play, 0x07, (reader) => new PlayClientStatistics(reader));
        Register(ConnectionState.Play, 0x63, (reader) => new PlayClientAdvancements(reader));
        Register(ConnectionState.Play, 0x09, (reader) => new PlayClientBlockBreakAnimation(reader));
        Register(ConnectionState.Play, 0x0a, (reader) => new PlayClientTileEntityData(reader));
        Register(ConnectionState.Play, 0x0b, (reader) => new PlayClientBlockAction(reader));
        Register(ConnectionState.Play, 0x0c, (reader) => new PlayClientBlockChange(reader));
        Register(ConnectionState.Play, 0x0d, (reader) => new PlayClientBossBar(reader));
        Register(ConnectionState.Play, 0x0e, (reader) => new PlayClientDifficulty(reader));
        Register(ConnectionState.Play, 0x11, (reader) => new PlayClientTabComplete(reader));
        Register(ConnectionState.Play, 0x12, (reader) => new PlayClientDeclareCommands(reader));
        Register(ConnectionState.Play, 0x37, (reader) => new PlayClientFacePlayer(reader));
        Register(ConnectionState.Play, 0x60, (reader) => new PlayClientNbtQueryResponse(reader));
        Register(ConnectionState.Play, 0x0f, (reader) => new PlayClientChat(reader));
        Register(ConnectionState.Play, 0x3f, (reader) => new PlayClientMultiBlockChange(reader));
        Register(ConnectionState.Play, 0x13, (reader) => new PlayClientCloseWindow(reader));
        Register(ConnectionState.Play, 0x2e, (reader) => new PlayClientOpenWindow(reader));
        Register(ConnectionState.Play, 0x14, (reader) => new PlayClientWindowItems(reader));
        Register(ConnectionState.Play, 0x15, (reader) => new PlayClientCraftProgressBar(reader));
        Register(ConnectionState.Play, 0x16, (reader) => new PlayClientSetSlot(reader));
        Register(ConnectionState.Play, 0x17, (reader) => new PlayClientSetCooldown(reader));
        Register(ConnectionState.Play, 0x18, (reader) => new PlayClientCustomPayload(reader));
        Register(ConnectionState.Play, 0x19, (reader) => new PlayClientNamedSoundEffect(reader));
        Register(ConnectionState.Play, 0x1a, (reader) => new PlayClientKickDisconnect(reader));
        Register(ConnectionState.Play, 0x1b, (reader) => new PlayClientEntityStatus(reader));
        Register(ConnectionState.Play, 0x1c, (reader) => new PlayClientExplosion(reader));
        Register(ConnectionState.Play, 0x1d, (reader) => new PlayClientUnloadChunk(reader));
        Register(ConnectionState.Play, 0x1e, (reader) => new PlayClientGameStateChange(reader));
        Register(ConnectionState.Play, 0x1f, (reader) => new PlayClientOpenHorseWindow(reader));
        Register(ConnectionState.Play, 0x21, (reader) => new PlayClientKeepAlive(reader));
        Register(ConnectionState.Play, 0x22, (reader) => new PlayClientMapChunk(reader));
        Register(ConnectionState.Play, 0x23, (reader) => new PlayClientWorldEvent(reader));
        Register(ConnectionState.Play, 0x24, (reader) => new PlayClientWorldParticles(reader));
        Register(ConnectionState.Play, 0x25, (reader) => new PlayClientUpdateLight(reader));
        Register(ConnectionState.Play, 0x26, (reader) => new PlayClientLogin(reader));
        Register(ConnectionState.Play, 0x27, (reader) => new PlayClientMap(reader));
        Register(ConnectionState.Play, 0x28, (reader) => new PlayClientTradeList(reader));
        Register(ConnectionState.Play, 0x29, (reader) => new PlayClientRelEntityMove(reader));
        Register(ConnectionState.Play, 0x2a, (reader) => new PlayClientEntityMoveLook(reader));
        Register(ConnectionState.Play, 0x2b, (reader) => new PlayClientEntityLook(reader));
        Register(ConnectionState.Play, 0x2c, (reader) => new PlayClientVehicleMove(reader));
        Register(ConnectionState.Play, 0x2d, (reader) => new PlayClientOpenBook(reader));
        Register(ConnectionState.Play, 0x2f, (reader) => new PlayClientOpenSignEntity(reader));
        Register(ConnectionState.Play, 0x31, (reader) => new PlayClientCraftRecipeResponse(reader));
        Register(ConnectionState.Play, 0x32, (reader) => new PlayClientAbilities(reader));
        Register(ConnectionState.Play, 0x33, (reader) => new PlayClientEndCombatEvent(reader));
        Register(ConnectionState.Play, 0x34, (reader) => new PlayClientEnterCombatEvent(reader));
        Register(ConnectionState.Play, 0x35, (reader) => new PlayClientDeathCombatEvent(reader));
        Register(ConnectionState.Play, 0x36, (reader) => new PlayClientPlayerInfo(reader));
        Register(ConnectionState.Play, 0x38, (reader) => new PlayClientPosition(reader));
        Register(ConnectionState.Play, 0x39, (reader) => new PlayClientUnlockRecipes(reader));
        Register(ConnectionState.Play, 0x3a, (reader) => new PlayClientEntityDestroy(reader));
        Register(ConnectionState.Play, 0x3b, (reader) => new PlayClientRemoveEntityEffect(reader));
        Register(ConnectionState.Play, 0x3c, (reader) => new PlayClientResourcePackSend(reader));
        Register(ConnectionState.Play, 0x3d, (reader) => new PlayClientRespawn(reader));
        Register(ConnectionState.Play, 0x3e, (reader) => new PlayClientEntityHeadRotation(reader));
        Register(ConnectionState.Play, 0x47, (reader) => new PlayClientCamera(reader));
        Register(ConnectionState.Play, 0x48, (reader) => new PlayClientHeldItemSlot(reader));
        Register(ConnectionState.Play, 0x49, (reader) => new PlayClientUpdateViewPosition(reader));
        Register(ConnectionState.Play, 0x4a, (reader) => new PlayClientUpdateViewDistance(reader));
        Register(ConnectionState.Play, 0x4c, (reader) => new PlayClientScoreboardDisplayObjective(reader));
        Register(ConnectionState.Play, 0x4d, (reader) => new PlayClientEntityMetadata(reader));
        Register(ConnectionState.Play, 0x4e, (reader) => new PlayClientAttachEntity(reader));
        Register(ConnectionState.Play, 0x4f, (reader) => new PlayClientEntityVelocity(reader));
        Register(ConnectionState.Play, 0x50, (reader) => new PlayClientEntityEquipment(reader));
        Register(ConnectionState.Play, 0x51, (reader) => new PlayClientExperience(reader));
        Register(ConnectionState.Play, 0x52, (reader) => new PlayClientUpdateHealth(reader));
        Register(ConnectionState.Play, 0x53, (reader) => new PlayClientScoreboardObjective(reader));
        Register(ConnectionState.Play, 0x54, (reader) => new PlayClientSetPassengers(reader));
        Register(ConnectionState.Play, 0x55, (reader) => new PlayClientTeams(reader));
        Register(ConnectionState.Play, 0x56, (reader) => new PlayClientScoreboardScore(reader));
        Register(ConnectionState.Play, 0x4b, (reader) => new PlayClientSpawnPosition(reader));
        Register(ConnectionState.Play, 0x59, (reader) => new PlayClientUpdateTime(reader));
        Register(ConnectionState.Play, 0x5c, (reader) => new PlayClientEntitySoundEffect(reader));
        Register(ConnectionState.Play, 0x5e, (reader) => new PlayClientStopSound(reader));
        Register(ConnectionState.Play, 0x5d, (reader) => new PlayClientSoundEffect(reader));
        Register(ConnectionState.Play, 0x5f, (reader) => new PlayClientPlayerlistHeader(reader));
        Register(ConnectionState.Play, 0x61, (reader) => new PlayClientCollect(reader));
        Register(ConnectionState.Play, 0x62, (reader) => new PlayClientEntityTeleport(reader));
        Register(ConnectionState.Play, 0x64, (reader) => new PlayClientEntityUpdateAttributes(reader));
        Register(ConnectionState.Play, 0x65, (reader) => new PlayClientEntityEffect(reader));
        Register(ConnectionState.Play, 0x40, (reader) => new PlayClientSelectAdvancementTab(reader));
        Register(ConnectionState.Play, 0x66, (reader) => new PlayClientDeclareRecipes(reader));
        Register(ConnectionState.Play, 0x67, (reader) => new PlayClientTags(reader));
        Register(ConnectionState.Play, 0x08, (reader) => new PlayClientAcknowledgePlayerDigging(reader));
        Register(ConnectionState.Play, 0x05, (reader) => new PlayClientSculkVibrationSignal(reader));
        Register(ConnectionState.Play, 0x10, (reader) => new PlayClientClearTitles(reader));
        Register(ConnectionState.Play, 0x20, (reader) => new PlayClientInitializeWorldBorder(reader));
        Register(ConnectionState.Play, 0x41, (reader) => new PlayClientActionBar(reader));
        Register(ConnectionState.Play, 0x42, (reader) => new PlayClientWorldBorderCenter(reader));
        Register(ConnectionState.Play, 0x43, (reader) => new PlayClientWorldBorderLerpSize(reader));
        Register(ConnectionState.Play, 0x44, (reader) => new PlayClientWorldBorderSize(reader));
        Register(ConnectionState.Play, 0x45, (reader) => new PlayClientWorldBorderWarningDelay(reader));
        Register(ConnectionState.Play, 0x46, (reader) => new PlayClientWorldBorderWarningReach(reader));
        Register(ConnectionState.Play, 0x30, (reader) => new PlayClientPing(reader));
        Register(ConnectionState.Play, 0x58, (reader) => new PlayClientSetTitleSubtitle(reader));
        Register(ConnectionState.Play, 0x5a, (reader) => new PlayClientSetTitleText(reader));
        Register(ConnectionState.Play, 0x5b, (reader) => new PlayClientSetTitleTime(reader));
        Register(ConnectionState.Play, 0x57, (reader) => new PlayClientSimulationDistance(reader));
        Register(ConnectionState.Play, 0x00, (reader) => new PlayServerTeleportConfirm(reader));
        Register(ConnectionState.Play, 0x01, (reader) => new PlayServerQueryBlockNbt(reader));
        Register(ConnectionState.Play, 0x02, (reader) => new PlayServerSetDifficulty(reader));
        Register(ConnectionState.Play, 0x0b, (reader) => new PlayServerEditBook(reader));
        Register(ConnectionState.Play, 0x0c, (reader) => new PlayServerQueryEntityNbt(reader));
        Register(ConnectionState.Play, 0x17, (reader) => new PlayServerPickItem(reader));
        Register(ConnectionState.Play, 0x20, (reader) => new PlayServerNameItem(reader));
        Register(ConnectionState.Play, 0x23, (reader) => new PlayServerSelectTrade(reader));
        Register(ConnectionState.Play, 0x24, (reader) => new PlayServerSetBeaconEffect(reader));
        Register(ConnectionState.Play, 0x26, (reader) => new PlayServerUpdateCommandBlock(reader));
        Register(ConnectionState.Play, 0x27, (reader) => new PlayServerUpdateCommandBlockMinecart(reader));
        Register(ConnectionState.Play, 0x2a, (reader) => new PlayServerUpdateStructureBlock(reader));
        Register(ConnectionState.Play, 0x06, (reader) => new PlayServerTabComplete(reader));
        Register(ConnectionState.Play, 0x03, (reader) => new PlayServerChat(reader));
        Register(ConnectionState.Play, 0x04, (reader) => new PlayServerClientCommand(reader));
        Register(ConnectionState.Play, 0x05, (reader) => new PlayServerSettings(reader));
        Register(ConnectionState.Play, 0x07, (reader) => new PlayServerEnchantItem(reader));
        Register(ConnectionState.Play, 0x08, (reader) => new PlayServerWindowClick(reader));
        Register(ConnectionState.Play, 0x09, (reader) => new PlayServerCloseWindow(reader));
        Register(ConnectionState.Play, 0x0a, (reader) => new PlayServerCustomPayload(reader));
        Register(ConnectionState.Play, 0x0d, (reader) => new PlayServerUseEntity(reader));
        Register(ConnectionState.Play, 0x0e, (reader) => new PlayServerGenerateStructure(reader));
        Register(ConnectionState.Play, 0x0f, (reader) => new PlayServerKeepAlive(reader));
        Register(ConnectionState.Play, 0x10, (reader) => new PlayServerLockDifficulty(reader));
        Register(ConnectionState.Play, 0x11, (reader) => new PlayServerPosition(reader));
        Register(ConnectionState.Play, 0x12, (reader) => new PlayServerPositionLook(reader));
        Register(ConnectionState.Play, 0x13, (reader) => new PlayServerLook(reader));
        Register(ConnectionState.Play, 0x14, (reader) => new PlayServerFlying(reader));
        Register(ConnectionState.Play, 0x15, (reader) => new PlayServerVehicleMove(reader));
        Register(ConnectionState.Play, 0x16, (reader) => new PlayServerSteerBoat(reader));
        Register(ConnectionState.Play, 0x18, (reader) => new PlayServerCraftRecipeRequest(reader));
        Register(ConnectionState.Play, 0x19, (reader) => new PlayServerAbilities(reader));
        Register(ConnectionState.Play, 0x1a, (reader) => new PlayServerBlockDig(reader));
        Register(ConnectionState.Play, 0x1b, (reader) => new PlayServerEntityAction(reader));
        Register(ConnectionState.Play, 0x1c, (reader) => new PlayServerSteerVehicle(reader));
        Register(ConnectionState.Play, 0x1f, (reader) => new PlayServerDisplayedRecipe(reader));
        Register(ConnectionState.Play, 0x1e, (reader) => new PlayServerRecipeBook(reader));
        Register(ConnectionState.Play, 0x21, (reader) => new PlayServerResourcePackReceive(reader));
        Register(ConnectionState.Play, 0x25, (reader) => new PlayServerHeldItemSlot(reader));
        Register(ConnectionState.Play, 0x28, (reader) => new PlayServerSetCreativeSlot(reader));
        Register(ConnectionState.Play, 0x29, (reader) => new PlayServerUpdateJigsawBlock(reader));
        Register(ConnectionState.Play, 0x2b, (reader) => new PlayServerUpdateSign(reader));
        Register(ConnectionState.Play, 0x2c, (reader) => new PlayServerArmAnimation(reader));
        Register(ConnectionState.Play, 0x2d, (reader) => new PlayServerSpectate(reader));
        Register(ConnectionState.Play, 0x2e, (reader) => new PlayServerBlockPlace(reader));
        Register(ConnectionState.Play, 0x2f, (reader) => new PlayServerUseItem(reader));
        Register(ConnectionState.Play, 0x22, (reader) => new PlayServerAdvancementTab(reader));
        Register(ConnectionState.Play, 0x1d, (reader) => new PlayServerPong(reader));
	}

	public static IPacket Create(IMinecraftReader reader, ConnectionState state, byte id) {
		if (!_factory.TryGetValue((state, id), out var func)) {
			throw new Exception($"Unknown packet id {id} for state {state}");
		}
		return func(reader);
	}

	private static void Register(ConnectionState state, byte id, Func<IMinecraftReader, IPacket> createFunc) {
		_factory[(state, id)] = createFunc;
	}
}
