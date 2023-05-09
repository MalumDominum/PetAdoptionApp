using Ardalis.Specification;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class UserByIdSpec : Specification<User>, ISingleResultSpecification<User>
{
	public UserByIdSpec(Guid id)
	{
		Query.Where(p => p.Id == id);
	}
}
