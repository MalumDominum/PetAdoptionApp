using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.Specifications.Extensions;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Specifications;

public sealed class PageUsersSpec : Specification<User>
{
	public PageUsersSpec(int? pageNumber, int pageLimit)
	{
		Query.Paginate(pageNumber, pageLimit);
	}
}
