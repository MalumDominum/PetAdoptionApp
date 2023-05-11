using ErrorOr;

namespace AuthProvider.Domain.Errors;

public static partial class Errors
{
	public static class User
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "User.NoRecordsFoundError",
			description: "No User was found with matching search parameters");

		public static Error NoSuchRecordFoundError = Error.NotFound(
			code: "User.NoSuchRecordFoundError",
			description: "User record with passed id didn't exist");
	}
}
