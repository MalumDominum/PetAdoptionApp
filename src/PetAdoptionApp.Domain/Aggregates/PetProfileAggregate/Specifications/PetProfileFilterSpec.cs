using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterSpec : Specification<PetProfile>
{
	public PetProfileFilterSpec(PetProfileFilteringValues filteringValues)
	{
		Query.PetProfileIncludeWithOrdering(true)
			 .OrderForList()
			 .Filter(filteringValues);
	}
}
