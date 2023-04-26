using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterPaginationSpec : Specification<PetProfile>
{
	public PetProfileFilterPaginationSpec(PetProfileFilteringValues filteringValues, int? pageNumber, int pageLimit)
	{
		Query.PetProfileIncludeWithOrdering(true)
			.OrderForList()
			.Paginate(pageNumber, pageLimit)
			.Filter(filteringValues);
	}
}
