using AuthProvider.Api.Models;
using AuthProvider.Application.Commands.Users.Create;
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

	[HttpPost("Register")]
	public async Task<IActionResult> Register(
		RegisterRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreateUserCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}
}
