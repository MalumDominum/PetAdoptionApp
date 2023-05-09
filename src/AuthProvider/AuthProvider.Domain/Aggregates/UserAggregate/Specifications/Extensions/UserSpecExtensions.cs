using Ardalis.Specification;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications.Extensions;

public static class UserSpecExtensions
{
	private const int LimitUsersValue = 10;

	public static ISpecificationBuilder<User> OrderForList(
		this ISpecificationBuilder<User> query)
	{
		return query.OrderBy(u => u.LastName)
					.ThenBy(u => u.FirstName);
	}

	public static ISpecificationBuilder<User> WithLimiting(
		this ISpecificationBuilder<User> query) => query.Take(LimitUsersValue);
}
