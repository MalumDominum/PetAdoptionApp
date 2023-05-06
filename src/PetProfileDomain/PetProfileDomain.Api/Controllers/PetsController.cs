using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Api.Models;
using PetProfileDomain.Application.Pets.Commands.Create;
using PetProfileDomain.Application.Pets.Commands.Delete;
using PetProfileDomain.Application.Pets.Commands.Update;
using PetProfileDomain.Application.Pets.Queries.ById;
using PetProfileDomain.Application.Pets.Queries.FilterablePage;

namespace PetProfileDomain.Api.Controllers;

[Route("api/PetProfiles")]
[Tags("PetProfiles")]
public class PetsController : ApiControllerBase
{
	private readonly ISender _mediator;

	private readonly IMapper _mapper;

	public PetsController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

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

	/// <summary>Creates a PetProfile</summary>
	/// <returns>A creation details</returns>
	/// <response code="201">Pet was successfully created</response>
	/// <response code="400">Passed Pet didn't pass the validation (see response details)</response>
	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> PostPet(PostPetRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(r => CreatedAtAction(nameof(GetPetById), new { id = result.Value.Id }, r), Problem);
	}

	[HttpPut]
	public async Task<IActionResult> PutPet(PutPetRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<UpdatePetCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeletePet(Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeletePetCommand(id), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
