using System.Text.RegularExpressions;
using FluentValidation;

namespace AuthProvider.Application.Commands.Users.Common;

public static class UserValidationExtensions
{
	public static IRuleBuilder<TCommand, string> Name<TCommand>(
		this IRuleBuilder<TCommand, string> rule) =>
		rule.Length(2, 50)
			.Matches(new Regex("^[-`'a-zA-Zа-яА-ЯіІїЇёЁєЄ]+$"))
			.WithMessage("Name must be given without whitespaces and only with cyrillic or latin symbols");

	public static IRuleBuilder<TCommand, string> Password<TCommand>(
		this IRuleBuilder<TCommand, string> rule) =>
		rule.Length(8, 32)
			.Matches(new Regex("^(?=.*\\d).+$"))
				.WithMessage("'Password' must contain at least one digit")
			.Matches(new Regex("^(?=.*[A-Z]).+$"))
				.WithMessage("'Password' must contain at least one uppercase letter")
			.Matches(new Regex("^(?=.*[a-z]).+$"))
				.WithMessage("'Password' must contain at least one lowercase letter");
}
