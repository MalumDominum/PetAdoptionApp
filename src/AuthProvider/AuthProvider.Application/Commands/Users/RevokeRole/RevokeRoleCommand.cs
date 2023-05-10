using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.RevokeRole;

public record RevokeRoleCommand(
	Guid RevokerUserId,
	Guid TargetUserId,
	int Role) : IRequest<ErrorOr<RevokeRoleCommandResult>>;
