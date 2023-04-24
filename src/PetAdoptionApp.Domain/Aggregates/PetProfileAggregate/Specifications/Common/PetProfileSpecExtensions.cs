using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;

public static class PetProfileSpecExtensions
{
	public static ISpecificationBuilder<PetProfile> PetProfileIncludeWithOrdering(
		this ISpecificationBuilder<PetProfile> query, bool onlyActiveStates)
	{
		query.Include(p => p.Size)
			 .Include(p => p.Species) //.Where(p => p.PhotoAndVideoUrls is {Count > 0});
			 .Include(p => p.Colors!.OrderBy(c => c.Id)); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});
		if (onlyActiveStates)
			query.Include(p => p.States!.Where(s => s.ResolvedDate == null).OrderBy(s => s.Status));
		else
			query.Include(p => p.States!.OrderBy(s => s.Status));
		return query;
	}

	public static ISpecificationBuilder<PetProfile> DetailedPetProfileIncludeWithOrdering(
		this ISpecificationBuilder<PetProfile> query)
	{
		return query.PetProfileIncludeWithOrdering(false)
					.Include(p => p.Details).ThenInclude(d => d!.Breed);
	}

	public static ISpecificationBuilder<PetProfile> OrderForList(
		this ISpecificationBuilder<PetProfile> query)
	{
		return query.OrderByDescending(p => p.NewStatesAddedAt)
					.ThenByDescending(p => p.CreatedAt);
	}

	public static ISpecificationBuilder<PetProfile> PaginateFrom(
		this ISpecificationBuilder<PetProfile> query, DateTime? paginationTime, int pageLimit)
	{
		return paginationTime != null 
			? query.Where(p => p.NewStatesAddedAt < paginationTime || p.NewStatesAddedAt == DateTime.MinValue)
				   .Take(pageLimit)
			: query.Take(pageLimit);
	}
}
