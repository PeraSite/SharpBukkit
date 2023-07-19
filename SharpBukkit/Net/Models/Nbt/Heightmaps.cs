using System.Linq;
using SharpBukkit.Net.Serialization;
using SharpNBT;

namespace SharpBukkit.Net.Models;

public record Heightmaps : INbtSerializable {
	public long[]? MotionBlocking { get; set; }
	public long[]? WorldSurface { get; set; }

	public CompoundTag Serialize() {
		var tag = new CompoundTag(null);
		if (MotionBlocking != null)
			tag.Add(new LongArrayTag("MOTION_BLOCKING", MotionBlocking));
		if (WorldSurface != null)
			tag.Add(new LongArrayTag("WORLD_SURFACE", WorldSurface));
		return tag;
	}

	public void Deserialize(CompoundTag tag) {
		var motBlock = tag["MOTION_BLOCKING"] as LongArrayTag ?? default;
		var worSurface = tag["WORLD_SURFACE"] as LongArrayTag ?? default;
		MotionBlocking = motBlock?.ToArray();
		WorldSurface = worSurface?.ToArray();
	}
}
