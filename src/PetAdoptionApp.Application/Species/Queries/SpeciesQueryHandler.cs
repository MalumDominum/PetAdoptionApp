using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Species.Queries;

public class SpeciesQueryHandler : IRequestHandler<SpeciesQuery, ErrorOr<SpeciesQueryResult>>
{
	private readonly IReadRepository<Domain.Aggregates.SpeciesAggregate.Species> _speciesRepository;

	public SpeciesQueryHandler(IReadRepository<Domain.Aggregates.SpeciesAggregate.Species> speciesRepository)
		=> _speciesRepository = speciesRepository;

	public async Task<ErrorOr<SpeciesQueryResult>> Handle(
		SpeciesQuery query, CancellationToken cancellationToken)
	{
		var result = await _speciesRepository.ListAsync(cancellationToken);
		return new SpeciesQueryResult(result);
	}
}
