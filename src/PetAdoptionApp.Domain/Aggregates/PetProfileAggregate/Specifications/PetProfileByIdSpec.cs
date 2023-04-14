using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileByIdSpec : Specification<PetProfile>
{
	public PetProfileByIdSpec(Guid id)
	{
		Query.Include(p => p.Species); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});

		Query.Include(p => p.Colors); //.Where(p => p.PhotoAndVideoUrls is {Count > 0});
		// TODO Test this
		Query.OrderBy(p => p.Colors!.OrderByDescending(c => c.Id));

		Query.Where(p => p.Id == id);
	}
}
