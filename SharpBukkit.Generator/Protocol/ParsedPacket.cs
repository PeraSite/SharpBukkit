using System;
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

internal record ParsedPacket {
	public PacketType Type { get; init; }

	public BoundType Bound { get; init; }

	public string Name { get; init; }

	public byte Id { get; init; }

	public List<PacketField> Fields { get; init; }

	public override string ToString() => $"[{Id}] {Name}: {string.Join(", ", Fields)}";
}

internal record PacketField {
	public string ActualType { get; init; }
	public string NativeType { get; init; }
	public string Name { get; init; }

	public override string ToString() => $"{Name} ({NativeType})";
}
