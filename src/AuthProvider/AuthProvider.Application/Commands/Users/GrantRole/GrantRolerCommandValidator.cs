using FluentValidation;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace AuthProvider.Application.Commands.Users.GrantRole;

public class GrantRoleCommandValidator : AbstractValidator<GrantRoleCommand>
{
	public GrantRoleCommandValidator()
	{
		RuleFor(c => c.Role).Must(x => Role.List.Select(r => r.Value).Contains(x))
			.WithMessage(c =>$"Status with provided role value \'{c.Role}\' dont exists");
	}
}
