using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileFilterPaginationSpec : Specification<PetProfile>
{
	public PetProfileFilterPaginationSpec(DateTime? paginationTime, PetProfileFilteringValues filter)
	{
		Query.PetProfileIncludeWithOrdering(true)
			 .OrderForList();

		if (!string.IsNullOrEmpty(filter.NameLike))
			Query.Search(p => p.Name.ToLower(), $"%{filter.NameLike.ToLower()}%");

		if (filter.Gender != null)
			Query.Where(p => p.Gender == filter.Gender);

		if (filter.SpeciesId != null)
			Query.Where(p => p.SpeciesId == filter.SpeciesId);

		if (filter.BreedIds != null)
			Query.Where(p => filter.BreedIds.Contains(p.Details!.BreedId!.Value));

		//if (filter.NearLocation != null)
		//	Implement Near logic

		if (filter.StateIds != null)
			Query.Where(p => p.States!.Any(state =>
				filter.StateIds.Any(id => state.Status == id)));
		
		if (filter.ColorIds != null)
			Query.Where(p => p.PetColors!.Count > 0 &&
			                 p.PetColors!.All(pc =>
				                 filter.ColorIds.Contains(pc.ColorId)));

		if (filter.SizeIds != null)
			Query.Where(p => filter.SizeIds.Contains(p.SizeId!.Value));

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
