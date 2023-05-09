using AuthProvider.Application.Commands.Users.Common;

namespace AuthProvider.Application.Commands.Users.Create;

public class RegisterCommandValidator : CreateUpdateUserCommandValidator<CreateUserCommand>
{
	public RegisterCommandValidator() { }
}
