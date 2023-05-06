using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Application.Breeds.Queries.List;
using PetProfileDomain.Application.Breeds.Queries.ListBySpeciesId;

namespace PetProfileDomain.Api.Controllers;

public class BreedsController : ApiControllerBase
{
	private readonly ISender _mediator;

	public BreedsController(ISender mediator) => _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetList(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new BreedsQuery(), cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpGet("{speciesId:int}")]
	public async Task<IActionResult> GetListBySpeciesId(int speciesId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new BreedsBySpeciesIdQuery(speciesId), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
