using ErrorOr;

namespace PetAdoptionApp.Domain.Errors;

public static partial class Errors
{
	public static class PetProfile
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "PetProfile.NoFurtherRecordsError",
			description: "Starting from this date further no more PetProfile records");
	}
}
