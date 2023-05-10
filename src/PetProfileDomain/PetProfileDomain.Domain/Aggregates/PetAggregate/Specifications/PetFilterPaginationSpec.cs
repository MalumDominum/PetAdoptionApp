using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.Specifications.Extensions;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Extensions;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetFilterPaginationSpec : Specification<Pet>
{
	public PetFilterPaginationSpec(PetFilteringValues filteringValues, int? pageNumber, int pageLimit)
	{
		Query.PetIncludeWithOrdering(true)
			 .OrderForList()
			 .Paginate(pageNumber, pageLimit)
			 .Filter(filteringValues);
	}
}
