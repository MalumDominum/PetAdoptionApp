using PetProfileDomain.Api.Models;
using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using Swashbuckle.AspNetCore.Filters;

namespace PetProfileDomain.Api.Controllers.ExampleProviders;

public class PostPetExampleProvider : IExamplesProvider<PostPetRequest>
{
	public PostPetRequest GetExamples() => new(
			Name: "Luna",
			Gender: Gender.Female,
			BirthDate: new PartialPossibleDate(2023, 2, null, false),
			Description: "Cute little kitty",
			SpeciesId: 1,
			SizeId: 1,
			ColorIds: new List<int> { 1, 2, 3 },
			Details: new PetDetailsCommandDto(
				BreedId: 3,
				Neutering: true,
				Healthy: false,
				Vaccination: true,
				HasPassport: false,
				HasCollar: true),
			Images: null,
			States: new List<int> { 1, 6 }
		);
}
