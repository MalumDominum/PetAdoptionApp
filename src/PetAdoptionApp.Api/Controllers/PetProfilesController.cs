using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Create;
using PetAdoptionApp.Application.PetProfiles.Commands.Delete;
using PetAdoptionApp.Application.PetProfiles.Commands.Update;
using PetAdoptionApp.Application.PetProfiles.Queries.ById;
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

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetPetProfileById(Guid id, CancellationToken cancellationToken)
	{
		var query = new PetByIdQuery(id);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpGet]
	public async Task<IActionResult> GetFilterablePage(
		[FromQuery] PagePetProfileRequest request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<FilterablePagePetsQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	/// <summary>Creates a PetProfile</summary>
	/// <returns>A creation details</returns>
	/// <response code="201">PetProfile was successfully created</response>
	/// <response code="400">Passed PetProfile didn't pass the validation (see response details)</response>
	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> PostPetProfile(PostPetProfileRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(r => CreatedAtAction(nameof(GetPetProfileById), new { id = result.Value.Id }, r), Problem);
	}

	[HttpPut]
	public async Task<IActionResult> PutPetProfile(PutPetProfileRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<UpdatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeletePetProfile(Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeletePetCommand(id), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
