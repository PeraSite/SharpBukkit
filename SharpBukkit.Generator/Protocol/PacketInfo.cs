using System.Collections.Generic;

namespace SharpBukkit.Generator.Protocol;

internal enum BoundType {
	Client,
	Server,
}

internal enum PacketType {
	Handshaking,
	Status,
	Login,
	Play,
}

internal record PacketInfo {
	public PacketType Type { get; init; }

	public BoundType Bound { get; init; }

	public string Name { get; init; }

	public byte Id { get; init; }

	public List<FieldInfo> Fields { get; init; }

	public override string ToString() => $"[{Id}] {Name}: {string.Join(", ", Fields)}";
}

internal record FieldInfo {
	public string ActualType { get; init; }
	public string NativeType { get; init; }
	public string Name { get; init; }

	public override string ToString() => $"{Name} ({NativeType})";
}
