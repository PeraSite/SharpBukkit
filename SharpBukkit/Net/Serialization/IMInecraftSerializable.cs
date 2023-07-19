using SharpBukkit.Net.Streams;
using SharpBukkit.Net.Utils;

namespace SharpBukkit.Net.Serialization;

public interface IMinecraftSerializable : ISerializable<IMinecraftWriter, IMinecraftReader> { }
