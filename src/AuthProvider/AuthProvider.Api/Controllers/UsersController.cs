using AuthProvider.Api.Models;
using AuthProvider.Application.Commands.Users.Delete;
using AuthProvider.Application.Commands.Users.Update;
using AuthProvider.Application.Queries.Auth.Authenticate;
using AuthProvider.Application.Queries.Users.ById;
using AuthProvider.Application.Queries.Users.ByIdUndetailed;
using AuthProvider.Application.Queries.Users.Search;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[Route("AuthProvider/[controller]")]
public class UsersController : ApiControllerBase
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	#region Constructor

	public UsersController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	#endregion

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UserByIdQuery(id), cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpGet("Undetailed/{id:guid}")]
	public async Task<IActionResult> GetUndetailedUserById(Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UserByIdUndetailedQuery(id), cancellationToken);
		return result.Match(Ok, Problem);
	}
	
	[HttpGet("Search/{searchValue}")]
	public async Task<IActionResult> SearchUsers(string searchValue, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new SearchUsersQuery(searchValue), cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpPut]
	public async Task<IActionResult> PutUser(
		UpdateUserRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<UpdateUserCommand>(request);
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}

	[Authorize]
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteUser(
		Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
