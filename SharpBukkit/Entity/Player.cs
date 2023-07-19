using System;
using SharpBukkit.API.Auth;
using SharpBukkit.API.Entity;

namespace SharpBukkit.Entity;

public class Player : IPlayer {
	public delegate IPlayer Factory(Guid id, string name);

	public Guid Id { get; set; }
	public string Name { get; set; }
	public string DisplayName { get; set; }
	public SkinProperty[] SkinProperties { get; set; }

	public Player(Guid id, string name) {
		Id = id;
		Name = name;
		DisplayName = name;
		SkinProperties = Array.Empty<SkinProperty>();
	}
}
