using Ardalis.Specification;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class UserForUpdateSpec : Specification<User>, ISingleResultSpecification<User>
{
	public UserForUpdateSpec(Guid id)
	{
		Query.Where(p => p.Id == id)
			 .AsNoTracking();
	}
}
