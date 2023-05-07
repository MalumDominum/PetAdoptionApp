using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Application.Queries.Colors;

namespace PetProfileDomain.Api.Controllers;

public class ColorsController : ApiControllerBase
{
	private readonly ISender _mediator;

	public ColorsController(ISender mediator) => _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetList(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ColorsQuery(), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
