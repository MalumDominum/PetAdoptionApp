using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Delete;

public record DeleteUserCommand(
	Guid UserId,
	bool ActionByOwner = false) : IRequest<ErrorOr<DeleteUserCommandResult>>;
