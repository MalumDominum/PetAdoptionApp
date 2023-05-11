using AuthProvider.Application.Commands.Users.Common;
using AuthProvider.Domain.Aggregates.UserAggregate.Enums;
using FluentValidation;

namespace AuthProvider.Application.Commands.Users.Create;

public class CreateUserCommandValidator : CreateUpdateUserCommandValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(u => u.FirstName).Name();
		RuleFor(u => u.LastName).Name();
		RuleFor(u => u.Password).Password();
		RuleFor(u => u.Email).MaximumLength(254).EmailAddress();
		RuleFor(u => u.Gender).Must(g => Gender.List.Select(x => x.Value).Contains(g))
			.WithMessage("'Gender' must be provided as one of this characters 'm', 'f' or 'o' (Other)");
	}
}
