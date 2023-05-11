using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class UsersByRoleSpec : Specification<User>
{
	public UsersByRoleSpec(Role role)
	{
		Query.Where(u => u.Permissions.Any(p => p.Role == role));
	}
}
