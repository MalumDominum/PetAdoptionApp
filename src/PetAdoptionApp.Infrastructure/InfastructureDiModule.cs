using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Infrastructure;

public static class InfrastructureDiModule
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		ConfigurationManager configuration, bool isDevelopment)
	{
		//if (isDevelopment) services.AddDevelopmentOnlyDependencies();
		//else services.AddProductionOnlyDependencies();

		services.AddDataAccess(configuration);
		return services;
	}

	private static IServiceCollection AddDataAccess(this IServiceCollection services,
		ConfigurationManager configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
					options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
		services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
		return services;
	}

	//private static IServiceCollection AddDevelopmentOnlyDependencies(this IServiceCollection services)
	//{
	//	services.AddScoped<IEmailSender, FakeEmailSender>();
	//	return services;
	//}

	//private static IServiceCollection AddProductionOnlyDependencies(this IServiceCollection services)
	//{
	//	services.AddScoped<IEmailSender, SmtpEmailSender>();
	//	return services;
	//}
}
