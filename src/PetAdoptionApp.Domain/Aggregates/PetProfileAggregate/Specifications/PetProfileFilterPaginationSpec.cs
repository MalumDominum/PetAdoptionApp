﻿using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterPaginationSpec : Specification<PetProfile>
{
	private const int PageLimit = 20;

	public PetProfileFilterPaginationSpec(DateTime? paginationTime, PetProfileFilteringValues filteringValues)
	{
		Query.PetProfileIncludeWithOrdering(true)
			.OrderForList()
			.PaginateFrom(paginationTime, PageLimit)
			.Filter(filteringValues);
	}
}
