using Ardalis.Specification;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Extensions;

public static class PetSpecExtensions
{
	public static ISpecificationBuilder<Pet> PetIncludeWithOrdering(
		this ISpecificationBuilder<Pet> query, bool onlyActiveStates)
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

	public static ISpecificationBuilder<Pet> DetailedPetIncludeWithOrdering(
		this ISpecificationBuilder<Pet> query)
	{
		return query.PetIncludeWithOrdering(false)
					.Include(p => p.Details).ThenInclude(d => d!.Breed);
	}

	public static ISpecificationBuilder<Pet> OrderForList(
		this ISpecificationBuilder<Pet> query)
	{
		return query.OrderByDescending(p => p.NewStatesAddedAt)
					.ThenByDescending(p => p.CreatedAt);
	}

	public static ISpecificationBuilder<Pet> Filter(
		this ISpecificationBuilder<Pet> query, PetFilteringValues filter)
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
				filter.StateIds.Any(id => state.Status == id) && state.ResolvedDate == null));

		if (filter.ColorIds != null)
			query.Where(p => p.PetColors!.Count > 0 &&
			                 p.PetColors!.All(pc =>
				                 filter.ColorIds.Contains(pc.ColorId)));

		if (filter.SizeIds != null)
			query.Where(p => filter.SizeIds.Contains(p.SizeId!.Value));

		if (filter.StatusChangedAfter != null)
			query.Where(p => p.NewStatesAddedAt < filter.StatusChangedAfter);

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
