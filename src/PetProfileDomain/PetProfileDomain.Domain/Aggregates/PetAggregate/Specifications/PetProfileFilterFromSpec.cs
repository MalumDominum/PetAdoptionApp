using Ardalis.Specification;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Common;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetFilterFromSpec : Specification<Pet>
{
	public PetFilterFromSpec(DateTime from, PetFilteringValues filteringValues)
	{
		Query.PetIncludeWithOrdering(true)
			 .OrderForList()
			 .Filter(filteringValues)
			 .Where(p => p.NewStatesAddedAt < from);
	}
}
