using MediatR.Pipeline;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.Domain.Aggregates.ProjectAggregate;
using PetAdoptionApp.Domain.Interfaces;
using PetAdoptionApp.Infrastructure.DataAccess;
using PetAdoptionApp.SharedKernel.Interfaces;
using PetAdoptionApp.SharedKernel;
using PetAdoptionApp.SharedKernel.Interfaces.DataAccess;

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
		var connectionString = configuration.GetConnectionString("SqliteConnection");
		services.AddDbContext(connectionString!);

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
