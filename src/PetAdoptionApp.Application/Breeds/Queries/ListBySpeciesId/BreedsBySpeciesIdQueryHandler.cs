using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate.Specifications;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Breeds.Queries.ListBySpeciesId;

public class BreedsBySpeciesIdQueryHandler : IRequestHandler<BreedsBySpeciesIdQuery, ErrorOr<BreedsBySpeciesIdQueryResult>>
{
	private readonly IReadRepository<Breed> _breedRepository;

	public BreedsBySpeciesIdQueryHandler(IReadRepository<Breed> breedRepository) => _breedRepository = breedRepository;

	public async Task<ErrorOr<BreedsBySpeciesIdQueryResult>> Handle(
		BreedsBySpeciesIdQuery query, CancellationToken cancellationToken)
	{
		var result = await _breedRepository.ListAsync(new BreedsBySpeciesIdSpec(query.SpeciesId), cancellationToken);
		return new BreedsBySpeciesIdQueryResult(result);
	}
}
