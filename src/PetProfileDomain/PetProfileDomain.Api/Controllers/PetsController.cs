using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.Authorization.Extensions;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Api.Models;
using PetProfileDomain.Application.Commands.Pets.Create;
using PetProfileDomain.Application.Commands.Pets.Delete;
using PetProfileDomain.Application.Commands.Pets.Transfer;
using PetProfileDomain.Application.Commands.Pets.Update;
using PetProfileDomain.Application.Queries.Pets.ById;
using PetProfileDomain.Application.Queries.Pets.FilterablePage;
using PetProfileDomain.Application.Queries.Pets.OwnedBy;

namespace PetProfileDomain.Api.Controllers;

[Tags("PetProfiles")]
[Route("PetDomain/PetProfiles")]
public class PetsController : ApiControllerBase
{
	private readonly ISender _mediator;

	private readonly IMapper _mapper;

	#region Constructor

	public PetsController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	#endregion

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetPetById(Guid id, CancellationToken cancellationToken)
	{
		var query = new PetByIdQuery(id);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpGet]
	public async Task<IActionResult> GetFilterablePage(
		[FromQuery] PagePetRequest request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<FilterablePagePetsQuery>(request);
		query.Request = Request;
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpGet("Owned/{ownerId:guid}")]
	public async Task<IActionResult> GetPetsOwnedBy(Guid ownerId,
		[FromQuery] int? pageNumber, CancellationToken cancellationToken)
	{
		var query = new PetsOwnedByQuery(pageNumber, ownerId, Request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	/// <summary>Creates a PetProfile</summary>
	/// <returns>A creation details</returns>
	/// <response code="201">Pet was successfully created</response>
	/// <response code="400">Passed Pet didn't pass the validation (see response details)</response>
	[Authorize]
	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> PostPet(PostPetRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreatePetCommand>(request);
		command.OwnerId = User.GetId();
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(r => CreatedAtAction(nameof(GetPetById), new { id = result.Value.Id }, r), Problem);
	}

	[Authorize]
	[HttpPut]
	public async Task<IActionResult> PutPet(PutPetRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<UpdatePetCommand>(request);
		command.OwnerId = User.GetId();
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[Authorize]
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeletePet(Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeletePetCommand(User.GetId(), id), cancellationToken);
		return result.Match(Ok, Problem);
	}

	[Authorize]
	[HttpPut("Transfer")]
	public async Task<IActionResult> TransferPetToNewOwner(TransferPetRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(
			new TransferPetCommand(User.GetId(), request.OwnerId, request.PetId),
			cancellationToken);
		return result.Match(Ok, Problem);
	}
}
