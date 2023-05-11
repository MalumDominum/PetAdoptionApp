using System.Security.Claims;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace PetAdoptionApp.SharedKernel.Authorization.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static Guid GetId(this ClaimsPrincipal user) => 
		Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

	public static List<Role> GetRoles(this ClaimsPrincipal user) =>
		user.FindAll(ClaimTypes.Role)
			.Select(r => Role.FromName(r.Value))
			.ToList();
}
