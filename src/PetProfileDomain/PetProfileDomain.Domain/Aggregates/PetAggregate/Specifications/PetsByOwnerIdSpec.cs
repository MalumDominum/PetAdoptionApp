using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.Specifications.Extensions;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Extensions;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetsByOwnerWithPaginationIdSpec : Specification<Pet>
{
	public PetsByOwnerWithPaginationIdSpec(int? pageNumber, int pageLimit, Guid ownerId)
	{
		Query.PetIncludeWithOrdering(false)
			 .OrderForList()
			 .Paginate(pageNumber, pageLimit)
			 .Where(p => p.OwnerId == ownerId);
	}
}
