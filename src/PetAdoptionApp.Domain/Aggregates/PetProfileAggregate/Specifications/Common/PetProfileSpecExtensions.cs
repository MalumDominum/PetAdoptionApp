using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

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

	public static ISpecificationBuilder<PetProfile> Filter(
		this ISpecificationBuilder<PetProfile> query, PetProfileFilteringValues filter)
	{
		if (!string.IsNullOrEmpty(filter.NameLike))
			query.Search(p => p.Name.ToLower(), $"%{filter.NameLike.ToLower()}%");

		if (filter.Gender != null)
			query.Where(p => p.Gender == filter.Gender);

		if (filter.SpeciesId != null)
			query.Where(p => p.SpeciesId == filter.SpeciesId);

		if (filter.BreedIds != null)
			query.Where(p => filter.BreedIds.Contains(p.Details!.BreedId!.Value));

		//if (filter.NearLocation != null)
		//	Implement Near logic

		if (filter.StateIds != null)
			query.Where(p => p.States!.Any(state =>
				filter.StateIds.Any(id => state.Status == id)));

		if (filter.ColorIds != null)
			query.Where(p => p.PetColors!.Count > 0 &&
			                 p.PetColors!.All(pc =>
				                 filter.ColorIds.Contains(pc.ColorId)));

		if (filter.SizeIds != null)
			query.Where(p => filter.SizeIds.Contains(p.SizeId!.Value));

		if (filter.BirthDateFrom != null)
			query.Where(p => p.BackfieldBirthDate >= filter.BirthDateFrom.Value);

		if (filter.BirthDateTo != null)
			query.Where(p => p.BackfieldBirthDate <= filter.BirthDateTo.Value);

		#region Details Filtering

		if (filter.Neutering != null)
			query.Where(p => p.Details!.Neutering == filter.Neutering);

		if (filter.Healthy != null)
			query.Where(p => p.Details!.Healthy == filter.Healthy);

		if (filter.Vaccination != null)
			query.Where(p => p.Details!.Vaccination == filter.Vaccination);

		if (filter.HasPassport != null)
			query.Where(p => p.Details!.HasPassport == filter.HasPassport);

		if (filter.HasCollar != null)
			query.Where(p => p.Details!.HasCollar == filter.HasCollar);

		#endregion

		return query;
	}
}
