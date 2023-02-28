using FastEndpoints.Swagger.Swashbuckle;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using PetAdoptionApp.Api.ErrorHandling;
using PetAdoptionApp.Api.Mapping;
using FastEndpoints.ApiExplorer;
using FastEndpoints;
using Ardalis.ListStartupServices;

namespace PetAdoptionApp.Api;
public static class ApiDiModule
{
	public static IServiceCollection AddPresentation(this IServiceCollection services, bool isDev)
	{
		services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
		services.AddMapping();
		services.AddFastEndpoints();
		services.AddFastEndpointsApiExplorer(); // For supporting Minimal API
		services.AddSwaggerDocumantation();
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

	public static IServiceCollection AddSwaggerDocumantation(this IServiceCollection services)
	{
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Pet Adoption API",
				Version = "v1",
				Description = "This is an API for Hand to Paw website"
			});
			c.EnableAnnotations();
			c.OperationFilter<FastEndpointsOperationFilter>();
		});
		return services;
	}
}
