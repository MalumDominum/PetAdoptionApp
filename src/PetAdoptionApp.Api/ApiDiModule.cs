﻿using Microsoft.OpenApi.Models;
using PetAdoptionApp.Api.Mapping;
using Ardalis.ListStartupServices;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

namespace PetAdoptionApp.Api;

public static class ApiDiModule
{
	public static IServiceCollection AddPresentation(this IServiceCollection services, bool isDev)
	{
		services.AddControllers();
		services.AddMapping()
			    .AddSwaggerDocumentation();
		if (isDev)
			// add list services page for diagnostic purposes
			services.Configure<ServiceConfig>(config =>
			{
				config.Services = new List<ServiceDescriptor>(services);
				config.Path = "/listservices";
			});
		//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure
		return services;
	}

	private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
	{
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Pet Adoption API",
				Version = "v1",
				Description = "This is an API for Hand to Paw website",
			});
			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

			c.ExampleFilters();
			c.OperationFilter<AddResponseHeadersFilter>();
		});
		services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
		return services;
	}
}
