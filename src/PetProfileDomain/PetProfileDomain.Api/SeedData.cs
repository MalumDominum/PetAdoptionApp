using Microsoft.EntityFrameworkCore;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Nesting;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;
using PetProfileDomain.Domain.Aggregates.SpeciesAggregate;
using PetProfileDomain.Domain.Aggregates.StateAggregate;
using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;
using PetProfileDomain.Infrastructure.DataAccess;

namespace PetProfileDomain.Api;

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
			if (!dbContext.Pets.Any()) InsertPetsForTesting(dbContext);
			if (!dbContext.States.Any()) InsertStatesForTesting(dbContext);
		}
    }

	#region Initial Data

	private static void InsertColors(AppDbContext context)
	{
		var insert = new List<Color>
		{
			new() { HexValue = "#ffffff", Title = "Білий" },
			new() { HexValue = "#000000", Title = "Чорний" },
			new() { HexValue = "#f6ead1", Title = "Абрикосовий" },
			new() { HexValue = "#613816", Title = "Коричневий"},
			new() { HexValue = "#d4905b", Title = "Золотистий" },
			new() { HexValue = "#a5aab2", Title = "Сірий" },
			new() { HexValue = "#fefee8", Title = "Кремовий" },
			new() { HexValue = "#e2ca9a", Title = "Русявий" },
			new() { HexValue = "#c4672f", Title = "Каштановий" }
		};
		foreach (var row in insert)
			context.Colors.Add(row);

		context.SaveChanges();
	}

	private static void InsertSpecies(AppDbContext context)
	{
		var insert = new List<Species>
		{
			new() { Title = "Кішка" },
			new() { Title = "Собака" },
			new() { Title = "Папуга" },
			new() { Title = "Морська свинка" },
			new() { Title = "Тхір" },
			new() { Title = "Щур" },
			new() { Title = "Шиншила" },
			new() { Title = "Кролик" },
			new() { Title = "Ящірка" },
			new() { Title = "Змія" },
			new() { Title = "Лис" },
			new() { Title = "Екзотичний" }
		};
		foreach (var row in insert)
			context.Species.Add(row);

		context.SaveChanges();
	}

	private static void InsertBreeds(AppDbContext context)
	{
		var insert = new List<Breed>
		{
			new() { Title = "Безпородний", SpeciesId = 1 },
			new() { Title = "Гібрид", SpeciesId = 1 },
			new() { Title = "Сіамський", SpeciesId = 1 },
			new() { Title = "Персидська", SpeciesId = 1 },
			new() { Title = "Мейн-кун", SpeciesId = 1 },
			new() { Title = "Регдолл", SpeciesId = 1 },
			new() { Title = "Бенгалський", SpeciesId = 1 },
			new() { Title = "Абіссінський", SpeciesId = 1 },
			new() { Title = "Бірман", SpeciesId = 1 },
			new() { Title = "Східна короткошерста", SpeciesId = 1 },
			new() { Title = "Сфінкс", SpeciesId = 1 },
			new() { Title = "Американський короткошерстий", SpeciesId = 1 },

			new() { Title = "Безпородний", SpeciesId = 2 },
			new() { Title = "Гібрид", SpeciesId = 2 },
			new() { Title = "Лабрадор-ретривер", SpeciesId = 2 },
			new() { Title = "Пудель", SpeciesId = 2 },
			new() { Title = "Бульдог", SpeciesId = 2 },
			new() { Title = "Ротвейлер", SpeciesId = 2 },
			new() { Title = "Бігль", SpeciesId = 2 },
			new() { Title = "Йоркширський тер'єр", SpeciesId = 2 },
			new() { Title = "Сибірська хаскі", SpeciesId = 2 },
			new() { Title = "Далматинець", SpeciesId = 2 }
		};
		foreach (var row in insert)
			context.Breeds.Add(row);

		context.SaveChanges();
	}

	private static void InsertSizes(AppDbContext context)
	{
		var insert = new List<Size>
		{
			new() { Title = "Малий", From = 0, To = 10 },
			new() { Title = "Середній", From = 10, To = 25 },
			new() { Title = "Великий", From = 25, To = 45 },
			new() { Title = "Дуже великий", From = 25, To = 60 }
		};
		foreach (var row in insert)
			context.Sizes.Add(row);

		context.SaveChanges();
	}

	#endregion

	#region Data for Testing

	private static void InsertPetsForTesting(AppDbContext context)
	{
		var ownerGuid = Guid.Parse("a0385d76-7f83-4016-bb5b-aa413959cf90");
		var insert = new List<Pet>
		{
			new() { Name = "Еліс", Gender = Gender.Female,
				Description = "**Коротка історія:**\nКошеня😻 - сіра красуня Еліс...",
				BirthDate = new PartialPossibleDate(2023, 2, 26, true), SpeciesId = 1, SizeId = 1,
				Details = null, OwnerId = ownerGuid },
			
			new() { Name = "Фенрір", Gender = Gender.Male,
				Description = "Божий син! БІЙТЕСЯ",
				BirthDate = new PartialPossibleDate(2022, 9), SpeciesId = 2, SizeId = 4,
				Details = new PetDetails { BreedId = 21, HasCollar = true, HasPassport = true, Healthy = true, Neutering = true, Vaccination = true },
				OwnerId = ownerGuid },

			new() { Name = "Шура", Gender = Gender.Female,
				Description = "Просто мила кішка",
				BirthDate = new PartialPossibleDate(2023), SpeciesId = 1, SizeId = null,
				Details = new PetDetails { BreedId = 1, HasPassport = false, Healthy = true, Neutering = true, Vaccination = false },
				OwnerId = ownerGuid }
		};
		foreach (var row in insert)
			context.Pets.Add(row);

		context.SaveChanges();
	}

	private static void InsertStatesForTesting(AppDbContext context)
	{
		var alice = context.Pets.FirstOrDefault(p => p.Name == "Еліс")!;
		var fenrir = context.Pets.FirstOrDefault(p => p.Name == "Фенрір")!;
		var cutie = context.Pets.FirstOrDefault(p => p.Name == "Шура")!;

		var insert = new List<State>
		{
			new() { Status = Status.Missing, AssignedTime = DateTime.UtcNow.AddDays(-10),
				ResolvedDate = DateTime.UtcNow.AddDays(-4), PetId = alice.Id },

			new() { Status = Status.Found, AssignedTime = DateTime.UtcNow.AddDays(-9),
				ResolvedDate = DateTime.UtcNow.AddDays(-1), PetId = fenrir.Id },

			new() { Status = Status.NeedsHome, AssignedTime = DateTime.UtcNow.AddDays(-1),
				ResolvedDate = null, PetId = fenrir.Id },

			new() { Status = Status.Found, AssignedTime = DateTime.UtcNow.AddDays(-15),
				ResolvedDate = null, PetId = cutie.Id }
		};
		foreach (var row in insert)
			context.States.Add(row);

		context.SaveChanges();
	}

	#endregion
}
