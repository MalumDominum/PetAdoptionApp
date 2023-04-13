using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Create;
using PetAdoptionApp.Application.PetProfiles.Commands.Update;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
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
	public async Task<IActionResult> GetPetProfileById(int id)
	{
		await Task.CompletedTask;
		return Ok();
	}

	[HttpGet]
	public async Task<IActionResult> GetFilterablePage(
		[FromQuery] PetProfilePageRequest request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<FilterablePagePetsQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpPost]
	public async Task<IActionResult> PostPetProfile(PostPetProfilePageRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpPut]
	public async Task<IActionResult> PutPetProfile(PutPetProfilePageRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<UpdatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}
}
