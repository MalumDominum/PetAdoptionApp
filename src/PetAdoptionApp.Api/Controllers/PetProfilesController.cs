using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Queries;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetAdoptionApp.Api.Controllers;

public class PetProfilesController : ApiControllerBase
{
	private readonly ISender _mediator;

	private readonly IMapper _mapper;

	public PetProfilesController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
		return Ok();
	}

	[HttpGet]
	public async Task<IActionResult> GetFilterablePage(
		[FromQuery] PetProfileFiltering request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<FilterablePagePetsQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}
}
