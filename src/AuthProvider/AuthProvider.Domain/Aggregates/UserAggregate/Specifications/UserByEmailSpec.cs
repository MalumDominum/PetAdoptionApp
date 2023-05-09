using Ardalis.Specification;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class UserByEmailSpec : Specification<User>, ISingleResultSpecification<User>
{
	public UserByEmailSpec(string email)
	{
		Query.Where(p => p.Email == email)
			 .AsNoTracking();
	}
}
