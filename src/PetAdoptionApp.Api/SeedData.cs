using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;
using PetAdoptionApp.Infrastructure.DataAccess;

namespace PetAdoptionApp.Api;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider, bool isDevelopment)
    {
	    using var dbContext = new AppDbContext(
		    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

		if (!dbContext.Colors.Any()) InsertColors(dbContext);
		if (!dbContext.Species.Any()) InsertSpecies(dbContext);
		if (isDevelopment)
		{
			if (!dbContext.PetProfiles.Any()) InsertPetProfilesForTesting(dbContext);
		}
    }

	public static void InsertColors(AppDbContext context)
	{
		var insert = new List<Color>
		{
			new() { HexValue = "#ffffff", Name = "White" },
			new() { HexValue = "#000000", Name = "Black" },
			new() { HexValue = "#f6ead1", Name = "Apricot" },
			new() { HexValue = "#613816", Name = "Brown"},
			new() { HexValue = "#d4905b", Name = "Golden" },
			new() { HexValue = "#a5aab2", Name = "Gray"},
			new() { HexValue = "#fefee8", Name = "Cream" },
			new() { HexValue = "#e2ca9a", Name = "Blond" },
			new() { HexValue = "#c4672f", Name = "Chestnut" }
		};
		foreach (var row in insert)
			context.Colors.Add(row);

		context.SaveChanges();
	}

	public static void InsertSpecies(AppDbContext context)
	{
		var insert = new List<Species>
		{
			new() { Title = "Cat" },		 // 1
			new() { Title = "Dog" },		 // 2
			new() { Title = "Parrot" },		 // 3
			new() { Title = "Guinea Pig" },	 // 4
			new() { Title = "Ferret" },		 // 5
			new() { Title = "Rat" },		 // 6
			new() { Title = "Chinchilla" },	 // 7
			new() { Title = "Rabbit" },		 // 8
			new() { Title = "Lizard" },		 // 9
			new() { Title = "Snake" },		 // 10
			new() { Title = "Fox" },		 // 11
			new() { Title = "Exotic" }		 // 12
		};
		foreach (var row in insert)
			context.Species.Add(row);

		context.SaveChanges();
	}

	#region Data for Testing

	private static void InsertPetProfilesForTesting(AppDbContext context)
	{
		var insert = new List<PetProfile>
		{
			new() { Name = "Alice", Gender = Gender.Female,
				Description = "**A short story:**\nA kitten😻 - gray-haired beauty Alice...",
				BirthDate = new PartialPossibleDate(2023, 2, 26, true), SpeciesId = 1 },
			new() { Name = "Fenrir", Gender = Gender.Male,
				Description = "A god sibling! FEAR",
				BirthDate = new PartialPossibleDate(2022, 9), SpeciesId = 2 },
			new() { Name = "Cutie", Gender = Gender.Female,
				Description = "Just cawai kitty",
				BirthDate = new PartialPossibleDate(2023), SpeciesId = 1 }
		};
		foreach (var row in insert)
			context.PetProfiles.Add(row);

		context.SaveChanges();
	}

	#endregion
}
