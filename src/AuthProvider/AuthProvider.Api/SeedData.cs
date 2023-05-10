using System.Runtime.CompilerServices;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Entities;
using AuthProvider.Domain.Aggregates.UserAggregate.Enums;
using AuthProvider.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.Providers;
using static BCrypt.Net.BCrypt;

namespace AuthProvider.Api;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider, bool isDevelopment)
    {
	    using var dbContext = new AppDbContext(
		    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

		if (!dbContext.Users.Any()) InsertAdmin(dbContext);
		if (isDevelopment && dbContext.Users.Count() <= 4) InsertUsersForTesting(dbContext);
    }

	#region Initial Data

	private static void InsertAdmin(AppDbContext context)
	{
		var guidList = Enumerable.Range(0, Role.List.Count - 1).Select(_ => Guid.NewGuid()).ToList();
		var insert = new List<User>
		{
			new()
			{ Id = guidList[0], Email = "rootadmin@example.com", FirstName = "Root", LastName = "Admin",
			  Gender = Gender.Other, PasswordHash = HashPassword("rootpassword"), RegistrationTime = DateTime.UtcNow,
			  Permissions = new List<Permission>
				  { new() { GrantedBy = guidList[0], GrantedTime = DateTime.UtcNow, Role = Role.RootAdmin } }},
			new()
			{ Id = guidList[1], Email = "admin@example.com", FirstName = "Admin", LastName = "Admin",
			  Gender = Gender.Other, PasswordHash = HashPassword("adminpassword"), RegistrationTime =DateTime.UtcNow,
			  Permissions = new List<Permission>
				  { new() { GrantedBy = guidList[1], GrantedTime = DateTime.UtcNow, Role = Role.Admin } }},
			new()
			{ Id = guidList[2], Email = "manager@example.com", FirstName = "Manager", LastName = "Manager",
			  Gender = Gender.Other, PasswordHash = HashPassword("managerpassword"), RegistrationTime = DateTime.UtcNow,
			  Permissions = new List<Permission>
			      { new() { GrantedBy = guidList[2], GrantedTime = DateTime.UtcNow, Role = Role.Manager },
				    new() { GrantedBy = guidList[3], GrantedTime = DateTime.UtcNow, Role = Role.Volunteer } }},
			new()
			{ Id = guidList[3], Email = "volunteer@example.com", FirstName = "Volunteer", LastName = "Volunteer",
			  Gender = Gender.Other, PasswordHash = HashPassword("volunteerpassword"), RegistrationTime = DateTime.UtcNow,
			  Permissions = new List<Permission>
				  { new() { GrantedBy = guidList[3], GrantedTime = DateTime.UtcNow, Role = Role.Volunteer } }}
		};
		foreach (var row in insert)
			context.Users.Add(row);

		context.SaveChanges();
	}

	#endregion

	#region Data for Testing

	private static void InsertUsersForTesting(AppDbContext context)
	{
		var guidList = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid()).ToList();
		var insert = new List<User>
		{
			new()
			{ Id = guidList[0], Email = "string", FirstName = "Root2", LastName = "Admin2",
				Gender = Gender.Other, PasswordHash = HashPassword("string"), RegistrationTime = DateTime.UtcNow,
				Permissions = new List<Permission>
					{ new() { GrantedBy = guidList[0], GrantedTime = DateTime.UtcNow, Role = Role.RootAdmin } }}
		};
		foreach (var row in insert)
			context.Users.Add(row);

		context.SaveChanges();
	}

	#endregion
}
