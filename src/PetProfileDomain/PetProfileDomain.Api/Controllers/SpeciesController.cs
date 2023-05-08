using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Application.Queries.Species;

namespace PetProfileDomain.Api.Controllers;

[Route("PetDomain/[controller]")]
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
