using System;
using System.Linq;
using SharpBukkit.Net.Serialization;
using SharpNBT;

namespace SharpBukkit.Net.Models;

public class DimensionCodec : INbtSerializable {
	public WorldCodec[] Realms { get; set; }
	public WorldBiome[] Biomes { get; set; }

	public CompoundTag Serialize() {
		var tag = new CompoundTag(null) {
			new CompoundTag("minecraft:dimension_type") {
				new StringTag("type", "minecraft:dimension_type"),
				new ListTag("value", TagType.Compound, Realms.Select(b => b.Serialize()))
			},
			new CompoundTag("minecraft:worldgen/biome") {
				new StringTag("type", "minecraft:worldgen/biome"),
				new ListTag("value", TagType.Compound, Biomes.Select(b => b.Serialize()))
			}
		};
		return tag;
	}

	public void Deserialize(CompoundTag tag) {
		throw new NotImplementedException();
	}
}
