using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetProfileDomain.Api.Controllers;

[Tags("PetProfiles")]
[Route("CityProjectDomain/[controller]")]
public class ProjectController : ApiControllerBase
{
	private readonly ISender _mediator;

	private readonly IMapper _mapper;

	#region Constructor

	public ProjectController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	#endregion

	[HttpGet("{id:guid}")]
	public Task<IActionResult> GetProjectById(Guid id, CancellationToken cancellationToken)
	{
		return Task.FromResult<IActionResult>(Ok());
	}
}
