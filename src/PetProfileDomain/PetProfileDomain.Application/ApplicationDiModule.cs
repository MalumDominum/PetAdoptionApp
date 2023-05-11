using System.Reflection;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.SharedKernel.Providers;
using PetAdoptionApp.SharedKernel.RabbitMq.Configuration;
using PetAdoptionApp.SharedKernel.RabbitMq.Exceptions;

namespace PetProfileDomain.Application;

public static class ApplicationDiModule
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		ConfigurationManager configuration)
	{
		//services.AddServices();

		services.AddMediatR(config =>
			config.RegisterServicesFromAssembly(typeof(ApplicationDiModule).Assembly));
		
		services.AddMassTransit(config =>
		{
			config.SetKebabCaseEndpointNameFormatter();
			config.UsingRabbitMq((_, cfg) =>
			{
				var rabbitMqConfig = configuration.GetSection("RabbitMQ").Get<RabbitMqConfig>();
				if (rabbitMqConfig == null) throw new RabbitMqInitException();
				cfg.Host(rabbitMqConfig.Host, rabbitMqConfig.Port, rabbitMqConfig.VirtualHost, h =>
				{
					h.Username(rabbitMqConfig.UserName);
					h.Password(rabbitMqConfig.Password);
				});
			});
		});

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		services.AddSingleton<IDateTimeProvider, DateTimeProviderWithoutTimezone>();

		return services;
	}

	//public static IServiceCollection AddServices(this IServiceCollection services) => services;
}
