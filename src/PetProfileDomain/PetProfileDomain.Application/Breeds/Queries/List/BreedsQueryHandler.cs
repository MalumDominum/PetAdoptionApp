using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Application.Breeds.Queries.List;

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
