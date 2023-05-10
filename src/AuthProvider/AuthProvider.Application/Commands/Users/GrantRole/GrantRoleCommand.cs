using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.GrantRole;

public record GrantRoleCommand(
	Guid GranterUserId,
	Guid AcceptorUserId,
	int Role) : IRequest<ErrorOr<GrantRoleCommandResult>>;
