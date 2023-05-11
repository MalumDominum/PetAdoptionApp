using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace PetProfileDomain.Domain.Errors;

public static partial class Errors
{
	public static class Pet
	{
		public static Error NoFurtherRecordsError = Error.NotFound(
			code: "Pet.NoFurtherRecordsError",
			description: "No Pet was found with matching search parameters");

		public static Error NoSuchRecordFoundError = Error.NotFound(
			code: "Pet.NoSuchRecordFoundError",
			description: "Pet record with passed id didn't exist");

		public static Error BreedNotBelongToSpeciesError = Error.Validation(
			code: "Pet.BreedNotBelongToSpeciesError",
			description: "The Breed not belong to specified Species. Please refetch Species again - maybe it outdated");

		public static Error NotPetOwnerError = Error.Custom(
			type: StatusCodes.Status403Forbidden,
			code: "Pet.NotPetOwnerError",
			description: "Youre not owner of the pet, since you can't transfer it to new owner");
	}
}
