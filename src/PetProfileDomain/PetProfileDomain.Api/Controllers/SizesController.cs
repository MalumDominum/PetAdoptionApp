using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Application.Sizes.Queries;

namespace PetProfileDomain.Api.Controllers;

public class SizesController : ApiControllerBase
{
	private readonly ISender _mediator;

	public SizesController(ISender mediator) => _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetList(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new SizesQuery(), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
