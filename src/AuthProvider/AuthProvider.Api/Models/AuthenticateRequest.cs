﻿namespace AuthProvider.Api.Models;

public record AuthenticateRequest(
	string Email,
	string Password);
