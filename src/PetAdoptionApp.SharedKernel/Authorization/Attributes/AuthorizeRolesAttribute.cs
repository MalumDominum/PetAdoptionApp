using Microsoft.AspNetCore.Authorization;
using PetAdoptionApp.SharedKernel.Authorization.Enums;
using static System.String;

namespace PetAdoptionApp.SharedKernel.Authorization.Attributes;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
	public AuthorizeRolesAttribute(string rolesText)
	{
		var roles = rolesText.Split(',')
							 .Select(r => Role.FromName(r.Trim()))
							 .ToList();
		var highRankedRoles = roles.Select(Role.IncludeHighRanked)
								   .SelectMany(x => x);

		Roles = Join(",", roles.Union(highRankedRoles).Distinct());
	}
}
