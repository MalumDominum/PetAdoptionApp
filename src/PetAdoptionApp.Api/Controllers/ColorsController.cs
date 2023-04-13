using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Application.Colors.Queries;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetAdoptionApp.Api.Controllers;

public class ColorsController : ApiControllerBase
{
	private readonly ISender _mediator;

	public ColorsController(ISender mediator) => _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetFilterablePage(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ColorsQuery(), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
