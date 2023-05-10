using AuthProvider.Api.Extensions;
using AuthProvider.Application.Commands.Users.GrantRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[Authorize]
[Route("AuthProvider/Roles")]
public class RolesController : ApiControllerBase
{
	private readonly ISender _mediator;
	
	public RolesController(ISender mediator) => _mediator = mediator;

	[HttpPost("Grant/{acceptorUserId:guid}")]
	public async Task<IActionResult> GrantRole(Guid acceptorUserId,
		[FromBody] int role, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(
			new GrantRoleCommand(User.GetId(), acceptorUserId, role),
			cancellationToken);
		return result.Match(Ok, Problem);
	}
}
