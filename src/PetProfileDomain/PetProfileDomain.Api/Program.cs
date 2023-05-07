﻿using Ardalis.ListStartupServices;
using Serilog;
using PetAdoptionApp.SharedKernel;
using PetProfileDomain.Api;
using PetProfileDomain.Application;
using PetProfileDomain.Infrastructure;
using PetProfileDomain.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var isDev = builder.Environment.IsDevelopment();
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddPresentation(isDev)
				.AddApplication()
				.AddInfrastructure(builder.Configuration, isDev)
				.AddSharedKernel();

var app = builder.Build();
{
	if (isDev)
	{
		app.UseDeveloperExceptionPage();
		app.UseShowAllServicesMiddleware();
	}
	else
	{
		app.UseExceptionHandler("/Error");
		app.UseHttpsRedirection();
		app.UseHsts();
	}
	app.UseRouting();
	app.MapControllers();

	//app.UseStaticFiles(); Add if will share files

	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Adoption API V1"));

	// Seed Database
	using (var scope = app.Services.CreateScope())
	{
		var services = scope.ServiceProvider;

		try
		{
			var context = services.GetRequiredService<AppDbContext>();
			//context.Database.Migrate();
			//context.Database.EnsureDeleted();
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