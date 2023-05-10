using AuthProvider.Application.Commands.Users.Common;

namespace AuthProvider.Application.Commands.Users.Create;

public class CreateUserCommandValidator : CreateUpdateUserCommandValidator<CreateUserCommand>
{
	public CreateUserCommandValidator() { }
}
