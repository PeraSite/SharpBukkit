using System;
using System.Numerics;
using SharpBukkit.API.Auth;
using SharpBukkit.API.Entity;

namespace SharpBukkit.Core.Entity;

public class Player : IPlayer {
	public Guid Id { get; set; }
	public Vector3 Position { get; set; }
	public string Name { get; set; }
	public string DisplayName { get; set; }
	public AuthResponse AuthResponse { get; set; }

	public Player(Guid id, string name) {
		Id = id;
		Name = name;
		DisplayName = name;
	}
}
