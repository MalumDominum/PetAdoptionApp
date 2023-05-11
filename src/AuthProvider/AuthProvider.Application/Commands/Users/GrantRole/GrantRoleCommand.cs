using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace AuthProvider.Application.Commands.Users.GrantRole;

public record GrantRoleCommand(
	Guid GranterUserId,
	List<Role> GranterRoles,
	Guid AcceptorUserId,
	int Role) : IRequest<ErrorOr<GrantRoleCommandResult>>;
