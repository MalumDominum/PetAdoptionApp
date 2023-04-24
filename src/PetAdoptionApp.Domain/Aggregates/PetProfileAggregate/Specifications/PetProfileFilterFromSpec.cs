using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterFromSpec : Specification<PetProfile>
{
	public PetProfileFilterFromSpec(DateTime from, PetProfileFilteringValues filteringValues)
	{
		Query.PetProfileIncludeWithOrdering(true)
			 .OrderForList()
			 .Filter(filteringValues)
			 .Where(p => p.NewStatesAddedAt < from);
	}
}
