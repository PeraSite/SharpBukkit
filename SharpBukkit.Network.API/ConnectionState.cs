﻿namespace SharpBukkit.Network.API;

public enum ConnectionState {
	Handshaking = 0,
	Status = 1,
	Login = 2,
	Play = 3
}