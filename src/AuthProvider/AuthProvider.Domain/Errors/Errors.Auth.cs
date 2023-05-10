using ErrorOr;

namespace AuthProvider.Domain.Errors;

public static partial class Errors
{
	public static class Auth
	{
		public static Error UserAlreadyExistsError = Error.Conflict(
			code: "Auth.UserAlreadyExistsError",
			description: "User with provided email already exists");

		public static Error WrongCredentialsError = Error.NotFound(
			code: "Auth.WrongCredentialsError",
			description: "User with provided email and password don't exists");

		public static Error UserAlreadyHasRoleError = Error.Conflict(
			code: "Auth.UserAlreadyHasRoleError",
			description: "User with provided id already has that role");

		public static Error UserHasNoSuchRoleError = Error.NotFound(
			code: "Auth.UserHasNoSuchRoleError",
			description: "User with provided id already don't have such role");
	}
}
