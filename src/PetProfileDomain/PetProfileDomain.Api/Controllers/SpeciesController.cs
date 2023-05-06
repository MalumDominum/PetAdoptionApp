using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Application.Species.Queries;

namespace PetProfileDomain.Api.Controllers;

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
