using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.Domain.Interfaces;
using PetAdoptionApp.Infrastructure.DataAccess;
using PetAdoptionApp.SharedKernel.Interfaces;
using PetAdoptionApp.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionApp.Infrastructure;

public static class InfastructureDiModule
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		ConfigurationManager configuration, bool isDevelopment)
	{
		if (isDevelopment) services.AddDevelopmentOnlyDependencies();
		else services.AddProductionOnlyDependencies();

		services.AddDataAccess(configuration);

		services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
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

	private static IServiceCollection AddDevelopmentOnlyDependencies(this IServiceCollection services)
	{
		services.AddScoped<IEmailSender, FakeEmailSender>();
		return services;
	}

	private static IServiceCollection AddProductionOnlyDependencies(this IServiceCollection services)
	{
		services.AddScoped<IEmailSender, SmtpEmailSender>();
		return services;
	}
}
