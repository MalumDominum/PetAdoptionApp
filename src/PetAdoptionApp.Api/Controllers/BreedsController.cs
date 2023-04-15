using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Application.Breeds.Queries.List;
using PetAdoptionApp.Application.Breeds.Queries.ListBySpeciesId;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetAdoptionApp.Api.Controllers;

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
