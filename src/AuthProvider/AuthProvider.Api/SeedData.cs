using AuthProvider.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AuthProvider.Api;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider, bool isDevelopment)
    {
	    using var dbContext = new AppDbContext(
		    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

		if (!dbContext.Users.Any()) InsertAdmin(dbContext);
		if (isDevelopment && !dbContext.Users.Any()) InsertUsersForTesting(dbContext);
    }

	#region Initial Data

	private static void InsertAdmin(AppDbContext context)
	{
		/*var insert = new List<Color>
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

		context.SaveChanges();*/
	}

	#endregion

	#region Data for Testing

	private static void InsertUsersForTesting(AppDbContext context)
	{
		/*var insert = new List<Pet>
		{
			new() { Name = "Alice", Gender = Gender.Female,
				Description = "**A short story:**\nA kitten😻 - gray-haired beauty Alice...",
				BirthDate = new PartialPossibleDate(2023, 2, 26, true), SpeciesId = 1, SizeId = 1,
				Details = null },
			
			new() { Name = "Fenrir", Gender = Gender.Male,
				Description = "A god sibling! FEAR",
				BirthDate = new PartialPossibleDate(2022, 9), SpeciesId = 2, SizeId = 4,
				Details = new PetDetails { BreedId = 21, HasCollar = true, HasPassport = true, Healthy = true, Neutering = true, Vaccination = true } },

			new() { Name = "Cutie", Gender = Gender.Female,
				Description = "Just cawai kitty",
				BirthDate = new PartialPossibleDate(2023), SpeciesId = 1, SizeId = null,
				Details = new PetDetails { BreedId = 1, HasPassport = false, Healthy = true, Neutering = true, Vaccination = false }}
		};
		foreach (var row in insert)
			context.Pets.Add(row);

		context.SaveChanges();*/
	}

	#endregion
}
