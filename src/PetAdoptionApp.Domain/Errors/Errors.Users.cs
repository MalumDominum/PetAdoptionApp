using ErrorOr;

namespace PetAdoptionApp.Domain.Errors;

public static class Errors
{
	public static class User
	{
		public static Error DuplicateEmail = Error.Conflict(
			code: "User.DuplicateEmail",
			description: "email is already in use.");

		public static Error WrongCredentials = Error.Conflict(
			code: "User.WrongCredentials",
			description: "You inputed email-password pair that doesn't match any account.");
	}
}
