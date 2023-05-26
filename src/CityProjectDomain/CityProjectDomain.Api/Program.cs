using Ardalis.ListStartupServices;
using CityProjectDomain.Api;
using CityProjectDomain.Application;
using CityProjectDomain.Infrastructure;
using CityProjectDomain.Infrastructure.DataAccess;
using PetAdoptionApp.SharedKernel;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var isDev = builder.Environment.IsDevelopment();

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddPresentation(isDev)
				.AddApplication(builder.Configuration)
				.AddInfrastructure(builder.Configuration, isDev)
				.AddSharedKernel(builder.Configuration);

var app = builder.Build();
{
	if (isDev)
	{
		app.UseDeveloperExceptionPage();
		app.UseShowAllServicesMiddleware();

		app.UseSwagger();
		app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Adoption API V1"));
	}
	else
	{
		app.UseExceptionHandler("PetDomain/Error");
		app.UseHttpsRedirection();
		app.UseHsts();
	}
	app.UseRouting();
	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
	app.MapHealthChecks("/-/healthy");

	// Seed Database
	using (var scope = app.Services.CreateScope())
	{
		var services = scope.ServiceProvider;

		try
		{
			var context = services.GetRequiredService<AppDbContext>();
			//context.Database.Migrate();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			SeedData.Initialize(services, isDev);
		}
		catch (Exception ex)
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error occurred while seeding the DB: {exceptionMessage}", ex.Message);
			throw new ("An error occurred while seeding the DB: " + ex.Message);
		}
	}
	app.Run();
}
