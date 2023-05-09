using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Application.Models.Species;
using PetProfileDomain.Domain.Aggregates.SpeciesAggregate.Specifications;

namespace PetProfileDomain.Application.Queries.Species;

public class SpeciesQueryHandler : IRequestHandler<SpeciesQuery, ErrorOr<SpeciesQueryResult>>
{
	private readonly IReadRepository<Domain.Aggregates.SpeciesAggregate.Species> _speciesRepository;

	private readonly IMapper _mapper;

	public SpeciesQueryHandler(IMapper mapper, IReadRepository<Domain.Aggregates.SpeciesAggregate.Species> speciesRepository)
	{
		_mapper = mapper;
		_speciesRepository = speciesRepository;
	}

	public async Task<ErrorOr<SpeciesQueryResult>> Handle(
		SpeciesQuery query, CancellationToken cancellationToken)
	{
		var result = await _speciesRepository.ListAsync(new SpeciesIncludingBreed(), cancellationToken);
		return new SpeciesQueryResult(_mapper.Map<List<SpeciesDto>>(result));
	}
}
