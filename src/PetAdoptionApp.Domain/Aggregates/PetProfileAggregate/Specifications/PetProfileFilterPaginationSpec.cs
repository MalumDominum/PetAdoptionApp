using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterPaginationSpec : Specification<PetProfile>
{
	public PetProfileFilterPaginationSpec(DateTime? paginationTime, PetProfileFilteringValues filter)
	{
		Query.Include(p => p.Colors); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});

		if (!string.IsNullOrEmpty(filter.NameLike))
			Query.Where(p => p.Name.ToLower().Contains(filter.NameLike.ToLower()));

		if (filter.Gender != null)
			Query.Where(p => p.Gender == filter.Gender);

		//if (filter.SpeciesId != null)
		//	Query.Where(p => p.SpeciesId == filter.SpeciesId);

		//if (filter.BreedId != null)
		//	Query.Where(p => p.BreedId == filter.BreedId);

		//if (filter.NearLocation != null)
		//	Implement Near logic

		//if (filter.StateIds != null)
		//	Query.Where(p => p.StateIds.Contains(StateIds));

		//if (filter.ColorIds != null)
		//	Query.Where(p => p.ColorIds.Contains(ColorIds));

		// TODO Implement comparing RangeOrValue<T> with T and HasValue method
		//if (filter.HeightFrom != null)
		//	Query.Where(p => p.Height >= filter.HeightFrom);

		//if (filter.HeightTo != null)
		//	Query.Where(p => p.Height <= filter.HeightTo);

		if (filter.BirthDateFrom != null)
			Query.Where(p => p.BackfieldBirthDate >= filter.BirthDateFrom.Value);

		if (filter.BirthDateTo != null)
			Query.Where(p => p.BackfieldBirthDate <= filter.BirthDateTo.Value);
		
		//if (filter.Neutering != null)
		//	Query.Where(p => p.Details.Neutering == filter.Neutering);

		//if (filter.Healthy != null)
		//	Query.Where(p => p.Details.Healthy == filter.Healthy);

		//if (filter.Vaccination != null)
		//	Query.Where(p => p.Details.Vaccination == filter.Vaccination);

		//if (filter.HasCollar != null)
		//	Query.Where(p => p.Details.HasCollar == filter.HasCollar);
	}
}
