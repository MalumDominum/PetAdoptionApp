using System.Reflection;
using AuthProvider.Application.Services;
using AuthProvider.Application.Services.Interfaces;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.SharedKernel.Providers;
using PetAdoptionApp.SharedKernel.RabbitMq.Configuration;
using PetAdoptionApp.SharedKernel.RabbitMq.Exceptions;

namespace AuthProvider.Application;

public static class ApplicationDiModule
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		ConfigurationManager configuration)
	{
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
		services.AddSingleton<ITokenProviderService, TokenProviderService>();

		return services;
	}
}
