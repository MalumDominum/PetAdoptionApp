using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Infrastructure.DataAccess;

namespace PetAdoptionApp.Api;
public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
    {
	    using var dbContext = new AppDbContext(
		    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
	    PopulateTestData(dbContext);
    }

    public static void PopulateTestData(AppDbContext dbContext) { }
}
