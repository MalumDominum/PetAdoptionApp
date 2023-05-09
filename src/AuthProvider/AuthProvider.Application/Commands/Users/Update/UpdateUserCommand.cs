using AuthProvider.Application.Commands.Users.Common;
using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Update;

public record UpdateUserCommand(
	Guid Id,
	string Email,
	byte[] PasswordHash,
	byte[] PasswordSalt,
	string FirstName,
	string LastName
	/*Gender Gender*/) : IRequest<ErrorOr<UpdateUserCommandResult>>, ICreateUpdateUserCommand;
