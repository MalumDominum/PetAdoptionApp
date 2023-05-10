using AuthProvider.Application.Commands.Users.Common;
using AuthProvider.Application.Models;
using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Commands.Users.Update;

public record UpdateUserCommand(
	DetailedUserDto User,
	bool ActionByOwner = false) : IRequest<ErrorOr<UpdateUserCommandResult>>, ICreateUpdateUserCommand;
