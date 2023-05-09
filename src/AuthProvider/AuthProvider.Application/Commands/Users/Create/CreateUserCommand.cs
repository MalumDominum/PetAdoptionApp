using AuthProvider.Application.Commands.Users.Common;
using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Create;

public record CreateUserCommand(
	string Email,
	byte[] PasswordHash,
	byte[] PasswordSalt,
	string FirstName,
	string LastName
	/*Gender Gender*/) : IRequest<ErrorOr<CreateUserCommandResult>>, ICreateUpdateUserCommand;
