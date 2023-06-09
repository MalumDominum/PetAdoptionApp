﻿using AuthProvider.Application.Commands.Users.GrantRole;
using AuthProvider.Application.Commands.Users.RevokeRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.Authorization.Extensions;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[Authorize]
[Route("AuthProvider/Users/[controller]")]
public class RolesController : ApiControllerBase
{
	private readonly ISender _mediator;
	
	public RolesController(ISender mediator) => _mediator = mediator;
	
	[HttpPost("Grant/{acceptorUserId:guid}")]
	public async Task<IActionResult> GrantRole(Guid acceptorUserId,
		[FromBody] int role, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(
			new GrantRoleCommand(User.GetId(), User.GetRoles(), acceptorUserId, role),
			cancellationToken);
		return result.Match(Ok, Problem);
	}

	[HttpDelete("Revoke/{targetUserId:guid}")]
	public async Task<IActionResult> RevokeRole(Guid targetUserId,
		[FromBody] int role, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(
			new RevokeRoleCommand(User.GetId(), User.GetRoles(), targetUserId, role),
			cancellationToken);
		return result.Match(Ok, Problem);
	}
}
