using ErrorOr;

namespace PetAdoptionApp.Domain.Errors;

public static partial class Errors
{
	public static class PetProfile
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "PetProfile.NoFurtherRecordsError",
			description: "Starting from this date further no more PetProfile records");

		public static Error NoSuchRecordFoundError = Error.NotFound(
			code: "PetProfile.NoSuchRecordFoundError",
			description: "PetProfile record with passed id didn't exist");

		public static Error BreedNotBelongToSpecies = Error.Validation(
			code: "PetProfile.BreedNotBelongToSpecies",
			description: "The Breed not belong to specified Species. Please refetch Species again - maybe it outdated");
	}
}
