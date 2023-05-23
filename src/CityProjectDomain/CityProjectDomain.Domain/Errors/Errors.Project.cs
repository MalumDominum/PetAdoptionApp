using ErrorOr;

namespace PetProfileDomain.Domain.Errors;

public static partial class Errors
{
	public static class Project
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "Project.NoFurtherRecordsError",
			description: "No Project was found with matching search parameters");

		public static Error NoSuchRecordFoundError = Error.NotFound(
			code: "Project.NoSuchRecordFoundError",
			description: "Project record with passed id didn't exist");
	}
}
