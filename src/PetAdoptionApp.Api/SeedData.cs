﻿using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Nesting;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;
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
		if (!dbContext.Breeds.Any()) InsertBreeds(dbContext);
		if (!dbContext.Sizes.Any()) InsertSizes(dbContext);
		if (isDevelopment)
		{
			if (!dbContext.PetProfiles.Any()) InsertPetProfilesForTesting(dbContext);
			if (!dbContext.States.Any()) InsertStatesForTesting(dbContext);
		}
    }

	#region Initial Data

	private static void InsertColors(AppDbContext context)
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

	private static void InsertSpecies(AppDbContext context)
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

	private static void InsertBreeds(AppDbContext context)
	{
		var insert = new List<Breed>
		{
			new() { Title = "Unbred", SpeciesId = 1 },
			new() { Title = "Hybrid", SpeciesId = 2 },
			new() { Title = "Siamese", SpeciesId = 1 },
			new() { Title = "Persian", SpeciesId = 1 },
			new() { Title = "Maine Coon", SpeciesId = 1 },
			new() { Title = "Ragdoll", SpeciesId = 1 },
			new() { Title = "Bengal", SpeciesId = 1 },
			new() { Title = "Abyssinian", SpeciesId = 1 },
			new() { Title = "Birman", SpeciesId = 1 },
			new() { Title = "Oriental Shorthair", SpeciesId = 1 },
			new() { Title = "Sphynx", SpeciesId = 1 },
			new() { Title = "American Shorthair", SpeciesId = 1 },

			new() { Title = "Unbred", SpeciesId = 2 },
			new() { Title = "Hybrid", SpeciesId = 2 },
			new() { Title = "Labrador Retrievers", SpeciesId = 2 },
			new() { Title = "Poodles", SpeciesId = 2 },
			new() { Title = "Bulldogs", SpeciesId = 2 },
			new() { Title = "Rottweilers", SpeciesId = 2 },
			new() { Title = "Beagles", SpeciesId = 2 },
			new() { Title = "Yorkshire Terriers", SpeciesId = 2 },
			new() { Title = "Siberian Huskies", SpeciesId = 2 },
			new() { Title = "Dalmatians", SpeciesId = 2 }
		};
		foreach (var row in insert)
			context.Breeds.Add(row);

		context.SaveChanges();
	}

	private static void InsertSizes(AppDbContext context)
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
				BirthDate = new PartialPossibleDate(2023, 2, 26, true), SpeciesId = 1, SizeId = 1,
				Details = null },
			
			new() { Name = "Fenrir", Gender = Gender.Male,
				Description = "A god sibling! FEAR",
				BirthDate = new PartialPossibleDate(2022, 9), SpeciesId = 2, SizeId = 4,
				Details = new PetProfileDetails { BreedId = 21, HasCollar = true, HasPassport = true, Healthy = true, Neutering = true, Vaccination = true } },

			new() { Name = "Cutie", Gender = Gender.Female,
				Description = "Just cawai kitty",
				BirthDate = new PartialPossibleDate(2023), SpeciesId = 1, SizeId = null,
				Details = new PetProfileDetails { BreedId = 1, HasPassport = false, Healthy = true, Neutering = true, Vaccination = false }}
		};
		foreach (var row in insert)
			context.PetProfiles.Add(row);

		context.SaveChanges();
	}

	private static void InsertStatesForTesting(AppDbContext context)
	{
		var petProfileIds = context.PetProfiles.Select(p => p.Id).ToList();

		var insert = new List<State>
		{
			new() { Status = Status.Missing, AssignedTime = DateTime.UtcNow.AddDays(-10),
				ResolvedDate = DateTime.UtcNow.AddDays(-4), PetProfileId = petProfileIds[0] },

			new() { Status = Status.Found, AssignedTime = DateTime.UtcNow.AddDays(-9),
				ResolvedDate = DateTime.UtcNow.AddDays(-1), PetProfileId = petProfileIds[1] },

			new() { Status = Status.NeedsHome, AssignedTime = DateTime.UtcNow.AddDays(-1),
				ResolvedDate = null, PetProfileId = petProfileIds[1] },

			new() { Status = Status.Found, AssignedTime = DateTime.UtcNow.AddDays(-15),
				ResolvedDate = null, PetProfileId = petProfileIds[2] }
		};
		foreach (var row in insert)
			context.States.Add(row);

		context.SaveChanges();
	}

	#endregion
}
