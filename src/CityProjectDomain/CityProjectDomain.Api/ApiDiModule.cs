﻿using System.Reflection;
using Ardalis.ListStartupServices;
using CityProjectDomain.Api.Mapping;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CityProjectDomain.Api;

public static class ApiDiModule
{
	public static IServiceCollection AddPresentation(this IServiceCollection services, bool isDev)
	{
		services.AddControllers();
		services.AddMapping();
		services.AddHealthChecks();

		//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

		if (!isDev) return services;
		services.AddSwaggerDocumentation();
		// add list services page for diagnostic purposes
		services.Configure<ServiceConfig>(config =>
		{
			config.Services = new List<ServiceDescriptor>(services);
			config.Path = "/listservices";
		});

		return services;
	}

	private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
	{
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Pet Adoption - CityProjects API",
				Version = "v1",
				Description = "This is an API for Hand to Paw website",
			});
			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

			c.ExampleFilters();
			c.OperationFilter<AddResponseHeadersFilter>();

			c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
			{
				Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
				In = ParameterLocation.Header,
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});
			c.OperationFilter<SecurityRequirementsOperationFilter>();
		});
		services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
		return services;
	}
}
