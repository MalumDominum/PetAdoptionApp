using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace AuthProvider.Application.Commands.Users.RevokeRole;

public record RevokeRoleCommand(
	Guid RevokerUserId,
	List<Role> RevokerRoles,
	Guid TargetUserId,
	int Role) : IRequest<ErrorOr<RevokeRoleCommandResult>>;
