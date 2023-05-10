﻿using System.Security.Claims;

namespace AuthProvider.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static Guid GetId(this ClaimsPrincipal user) => Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
