using AuthProvider.Application.Commands.Users.Common;
using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Create;

public record CreateUserCommand(
	string Email,
	string Password,
	string FirstName,
	string LastName,
	string Gender) : IRequest<ErrorOr<CreateUserCommandResult>>, ICreateUpdateUserCommand;
