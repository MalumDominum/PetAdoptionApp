using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Delete;

public record DeleteUserCommand(Guid PetId) : IRequest<ErrorOr<DeleteUserCommandResult>>;
