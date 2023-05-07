using PetProfileDomain.Api.Models;
using PetProfileDomain.Application.Queries.Pets.Commands.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using Swashbuckle.AspNetCore.Filters;

namespace PetProfileDomain.Api.Controllers.ExampleProviders;

public class PutPetExampleProvider : IExamplesProvider<PutPetRequest>
{
	public PutPetRequest GetExamples() => new(
			Id: Guid.Empty,
			Name: "Fluffy",
			Gender: Gender.Male,
			BirthDate: new PartialPossibleDate(2020, 12, 21, true),
			Description: "Small fuzzy dog",
			SpeciesId: 2,
			SizeId: 1,
			ColorIds: new List<int> { 1, 5 },
			Details: new PetDetailsCommandDto(
				BreedId: null,
				Neutering: true,
				Healthy: true,
				Vaccination: false,
				HasPassport: false,
				HasCollar: null),
			States: new List<int> { 2 }
		);
}
