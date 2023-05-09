using AuthProvider.Application.Commands.Users.Common;

namespace AuthProvider.Application.Commands.Users.Update;

public class UpdatePetCommandValidator : CreateUpdateUserCommandValidator<UpdateUserCommand>
{
	public UpdatePetCommandValidator() { }
}
