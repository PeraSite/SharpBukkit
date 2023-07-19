using SharpBukkit.API.Auth;

namespace SharpBukkit.API.Entity;

public interface IPlayer : IEntity {
	public string Name { get; set; }
	public string DisplayName { get; set; }
	public SkinProperty[] SkinProperties { get; set; }
}
