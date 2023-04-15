using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Breeds.Queries.List;

public class BreedsQueryHandler : IRequestHandler<BreedsQuery, ErrorOr<BreedsQueryResult>>
{
	private readonly IReadRepository<Breed> _breedRepository;

	public BreedsQueryHandler(IReadRepository<Breed> breedRepository) => _breedRepository = breedRepository;

	public async Task<ErrorOr<BreedsQueryResult>> Handle(
		BreedsQuery query, CancellationToken cancellationToken)
	{
		var result = await _breedRepository.ListAsync(cancellationToken);
		return new BreedsQueryResult(result);
	}
}
