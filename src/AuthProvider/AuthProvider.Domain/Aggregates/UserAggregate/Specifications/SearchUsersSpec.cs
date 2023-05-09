using Ardalis.Specification;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications.Extensions;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class SearchUsersSpec : Specification<User>
{
	public SearchUsersSpec(string searchValue)
	{
		Query.OrderForList()
			 .WithLimiting()
			 .Search(u => u.LastName.ToLower() + " " + u.FirstName.ToLower(), $"%{searchValue.ToLower()}%")
			 .Search(u => u.FirstName.ToLower() + " " + u.LastName.ToLower(), $"%{searchValue.ToLower()}%");
	}
}
