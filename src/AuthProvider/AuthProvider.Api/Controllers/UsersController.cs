using AuthProvider.Api.Models;
using AuthProvider.Application.Commands.Users.Delete;
using AuthProvider.Application.Commands.Users.Update;
using AuthProvider.Application.Models;
using AuthProvider.Application.Queries.Users.ById;
using AuthProvider.Application.Queries.Users.ByIdUndetailed;
using AuthProvider.Application.Queries.Users.Search;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.Authorization.Extensions;
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

	[Authorize]
	[HttpPut]
	public async Task<IActionResult> PutUserByOwner(
		UpdateUserByOwnerRequest request, CancellationToken cancellationToken)
	{
		var user = _mapper.Map<DetailedUserDto>(request);
		user.Id = User.GetId();
		var result = await _mediator.Send(new UpdateUserCommand(user, true), cancellationToken);
		return result.Match(Ok, Problem);
	}

	[Authorize]
	[HttpDelete]
	public async Task<IActionResult> DeleteUserByOwner(CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeleteUserCommand(User.GetId(), true), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
