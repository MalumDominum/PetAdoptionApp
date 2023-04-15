using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterPaginationSpec : Specification<PetProfile>
{
	public PetProfileFilterPaginationSpec(DateTime? paginationTime, PetProfileFilteringValues filter)
	{
		Query.Include(p => p.Species); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});
		Query.Include(p => p.Colors); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});
		Query.Include(p => p.Size);

		if (!string.IsNullOrEmpty(filter.NameLike))
			Query.Where(p => p.Name.ToLower().Contains(filter.NameLike.ToLower()));

		if (filter.Gender != null)
			Query.Where(p => p.Gender == filter.Gender);

		if (filter.SpeciesId != null)
			Query.Where(p => p.SpeciesId == filter.SpeciesId);

		if (filter.BreedIds != null)
			Query.Where(p => p.Details!.BreedId != null &&
			                 filter.BreedIds.Contains(p.Details.BreedId.Value));

		//if (filter.NearLocation != null)
		//	Implement Near logic

		//if (filter.StateIds != null)
		//	Query.Where(p => p.StateIds.Contains(StateIds));

		// TODO This doesn't work. Bring it in PetColor spec
		//if (filter.ColorIds != null)
		//	Query.Where(p => filter.ColorIds.All(fc => p.Colors!.Select(c => c.Id).Contains(fc)));

		if (filter.SizeIds != null)
			Query.Where(p => p.SizeId != null &&
			                 filter.SizeIds.Contains(p.SizeId.Value));

		if (filter.BirthDateFrom != null)
			Query.Where(p => p.BackfieldBirthDate >= filter.BirthDateFrom.Value);

		if (filter.BirthDateTo != null)
			Query.Where(p => p.BackfieldBirthDate <= filter.BirthDateTo.Value);

		#region Details Filtering

		if (filter.Neutering != null)
			Query.Where(p => p.Details!.Neutering == filter.Neutering);

		if (filter.Healthy != null)
			Query.Where(p => p.Details!.Healthy == filter.Healthy);

		if (filter.Vaccination != null)
			Query.Where(p => p.Details!.Vaccination == filter.Vaccination);

		if (filter.HasPassport != null)
			Query.Where(p => p.Details!.HasPassport == filter.HasPassport);

		if (filter.HasCollar != null)
			Query.Where(p => p.Details!.HasCollar == filter.HasCollar);

		#endregion
	}
}
