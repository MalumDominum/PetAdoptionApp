using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Application.Species.Queries;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetAdoptionApp.Api.Controllers;

public class SpeciesController : ApiControllerBase
{
	private readonly ISender _mediator;

	public SpeciesController(ISender mediator) => _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetList(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new SpeciesQuery(), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
