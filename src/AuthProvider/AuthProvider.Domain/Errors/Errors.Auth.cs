using ErrorOr;
using Microsoft.AspNetCore.Http;

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
		
		public static Error HasNoPermissionToGrantRoleError = Error.Custom(
			type: StatusCodes.Status403Forbidden,
			code: "Auth.HasNoPermissionToGrantRoleError",
			description: "You don't have permission to grant this role");
		
		public static Error HasNoPermissionToRevokeRoleError = Error.Custom(
			type: StatusCodes.Status403Forbidden,
			code: "Auth.HasNoPermissionToGrantRoleError",
			description: "You don't have permission to revoke this role");

		public static Error UserAlreadyHasRoleError = Error.Conflict(
			code: "Auth.UserAlreadyHasRoleError",
			description: "User with provided id already has that role");

		public static Error UserHasNoSuchRoleError = Error.NotFound(
			code: "Auth.UserHasNoSuchRoleError",
			description: "User with provided id already don't have such role");
	}
}
