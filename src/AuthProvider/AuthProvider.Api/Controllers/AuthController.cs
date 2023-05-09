using AuthProvider.Api.Models;
using AuthProvider.Application.Queries.Auth.Authenticate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[Route("AuthProvider/[controller]")]
public class AuthController : ApiControllerBase
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	#region Constructor

	public AuthController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	#endregion

	[HttpPost]
	public async Task<IActionResult> Authenticate(
		AuthenticateRequest request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<AuthenticateQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.Match(Ok, Problem);
	}

	/*[HttpPost("register")]
	public async Task<IActionResult> Register(UserDTO user)
	{
		var response = await _service.RegisterAsync(user);

		if (response == null)
			return BadRequest("Didn't register!");

		return Ok(response);
	}*/
}
