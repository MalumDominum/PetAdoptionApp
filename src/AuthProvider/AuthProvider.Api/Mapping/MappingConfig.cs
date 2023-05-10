﻿using AuthProvider.Application.Commands.Users.Create;
using AuthProvider.Application.Commands.Users.Update;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Enums;
using Mapster;
using PetAdoptionApp.SharedKernel.Providers;
using static BCrypt.Net.BCrypt;

namespace AuthProvider.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateUserCommand, User>()
		    .Map(dest => dest.PasswordHash, src => HashPassword(src.Password))
			.AfterMapping(p => p.RegistrationTime = UtcNow());

		config.NewConfig<UpdateUserCommand, User>()
			.Ignore(dest => dest.Email)
			.Ignore(dest => dest.PasswordHash);


		config.NewConfig<Role, int>()
			.Map(dest => dest, src => src.Value);

		config.NewConfig<int, Role>()
			.MapWith(src => Role.List.Select(g => g.Value).Contains(src)
				? Role.FromValue(src)
				: Role.User);

		config.NewConfig<Gender, string>()
			.Map(dest => dest, src => src.Value);

		config.NewConfig<string, Gender>()
			.MapWith(src => Gender.List.Select(g => g.Value).Contains(src)
				? Gender.FromValue(src)
				: Gender.Other);
	}

	private static DateTime UtcNow() => MapContext.Current.GetService<IDateTimeProvider>().UtcNow;
}
