using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;
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
		if (!dbContext.Sizes.Any()) InsertHeights(dbContext);
		if (isDevelopment)
		{
			if (!dbContext.PetProfiles.Any()) InsertPetProfilesForTesting(dbContext);
		}
    }

	#region Initial Data

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
			new() { Title = "Cat" },
			new() { Title = "Dog" },
			new() { Title = "Parrot" },
			new() { Title = "Guinea Pig" },
			new() { Title = "Ferret" },
			new() { Title = "Rat" },
			new() { Title = "Chinchilla" },
			new() { Title = "Rabbit" },
			new() { Title = "Lizard" },
			new() { Title = "Snake" },
			new() { Title = "Fox" },
			new() { Title = "Exotic" }
		};
		foreach (var row in insert)
			context.Species.Add(row);

		context.SaveChanges();
	}

	public static void InsertHeights(AppDbContext context)
	{
		var insert = new List<Size>
		{
			new() { Title = "Small", From = 0, To = 10 },
			new() { Title = "Medium", From = 10, To = 25 },
			new() { Title = "Large", From = 25, To = 45 },
			new() { Title = "Extra-Large", From = 25, To = 60 }
		};
		foreach (var row in insert)
			context.Sizes.Add(row);

		context.SaveChanges();
	}

	#endregion

	#region Data for Testing

	private static void InsertPetProfilesForTesting(AppDbContext context)
	{
		var insert = new List<PetProfile>
		{
			new() { Name = "Alice", Gender = Gender.Female,
				Description = "**A short story:**\nA kitten😻 - gray-haired beauty Alice...",
				BirthDate = new PartialPossibleDate(2023, 2, 26, true), SpeciesId = 1, SizeId = 1 },
			new() { Name = "Fenrir", Gender = Gender.Male,
				Description = "A god sibling! FEAR",
				BirthDate = new PartialPossibleDate(2022, 9), SpeciesId = 2, SizeId = 4 },
			new() { Name = "Cutie", Gender = Gender.Female,
				Description = "Just cawai kitty",
				BirthDate = new PartialPossibleDate(2023), SpeciesId = 1, SizeId = null }
		};
		foreach (var row in insert)
			context.PetProfiles.Add(row);

		context.SaveChanges();
	}

	#endregion
}
