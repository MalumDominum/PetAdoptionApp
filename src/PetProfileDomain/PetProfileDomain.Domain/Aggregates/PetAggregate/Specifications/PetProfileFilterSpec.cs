using Ardalis.Specification;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Common;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetFilterSpec : Specification<Pet>
{
	public PetFilterSpec(PetFilteringValues filteringValues)
	{
		Query.PetIncludeWithOrdering(true)
			 .OrderForList()
			 .Filter(filteringValues);
	}
}
