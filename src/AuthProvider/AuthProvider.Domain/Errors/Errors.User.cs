using ErrorOr;

namespace AuthProvider.Domain.Errors;

public static partial class Errors
{
	public static class User
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "User.NoFurtherRecordsError",
			description: "Starting from this date further no more Pet records");

		public static Error NoSuchRecordFoundError = Error.NotFound(
			code: "User.NoSuchRecordFoundError",
			description: "Pet record with passed id didn't exist");
	}
}
