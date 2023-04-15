﻿using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Application.Species.Models;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate.Specifications;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Species.Queries;

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
