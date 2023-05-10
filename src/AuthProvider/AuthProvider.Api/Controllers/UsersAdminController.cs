using AuthProvider.Api.Models;
using AuthProvider.Application.Commands.Users.Delete;
using AuthProvider.Application.Commands.Users.Update;
using AuthProvider.Application.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.Authorization.Attributes;
using PetAdoptionApp.SharedKernel.Authorization.Enums;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[AuthorizeRoles(nameof(Role.Admin))]
[Route("AuthProvider/Users/Admin")]
public class UsersAdminController : ApiControllerBase
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	#region Constructor

	public UsersAdminController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	#endregion

	[HttpPut]
	public async Task<IActionResult> PutUser(
		UpdateUserRequest request, CancellationToken cancellationToken)
	{
		var command = new UpdateUserCommand(_mapper.Map<DetailedUserDto>(request));
		var result = await _mediator.Send(command, cancellationToken);
		return result.Match(Ok, Problem);
	}
	
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteUser(
		Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
		return result.Match(Ok, Problem);
	}
}
