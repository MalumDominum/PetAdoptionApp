using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.BreedAggregate.Specifications;

namespace PetProfileDomain.Application.Breeds.Queries.ListBySpeciesId;

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
