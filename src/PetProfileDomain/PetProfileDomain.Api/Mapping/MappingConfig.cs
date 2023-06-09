﻿using Mapster;
using PetAdoptionApp.SharedKernel.Providers;
using PetProfileDomain.Api.Models;
using PetProfileDomain.Application.Commands.Pets.Create;
using PetProfileDomain.Application.Commands.Pets.Transfer;
using PetProfileDomain.Application.Commands.Pets.Update;
using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Application.Models.Pets.Nesting;
using PetProfileDomain.Application.Queries.Pets.FilterablePage;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Entities;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.StateAggregate;
using static System.String;

namespace PetProfileDomain.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PagePetRequest, FilterablePagePetsQuery>()
	        .Map(dest => dest.Filtering, src => src);

        config.NewConfig<CreatePetCommand, Pet>()
	        .Map(dest => dest.PetColors, src => src.ColorIds)
	        .AfterMapping(p =>
	        {
		        p.CreatedAt = UtcNow();
				if (p.States is { Count: > 0 })
					p.NewStatesAddedAt = UtcNow();
	        });

        config.NewConfig<UpdatePetCommand, Pet>()
	        .Map(dest => dest.PetColors, src => src.ColorIds)
	        .Ignore(dest => dest.OwnerId)
	        .AfterMapping(p => p.EditedAt = UtcNow());

		config.NewConfig<Pet, PetInListDto>()
	        .Map(dest => dest.ActiveStates, src => src.States);

		config.NewConfig<TransferPetCommand, TransferFact>()
			.AfterMapping(p => p.TransferDateTime = UtcNow());

		config.NewConfig<List<int>?, List<PetColor>?>()
			.MapWith(src => src != null
				? src.Select(colorId => new PetColor(colorId)).ToList()
				: null);

		config.NewConfig<List<int>?, List<State>?>()
	        .MapWith(src => src != null
		        ? src.Select(status => new State(status, UtcNow())).ToList()
		        : null);

		config.NewConfig<List<State>?, SeparatedStates>()
			.MapWith(src => src != null
				? new SeparatedStates(
					src.Where(s => s.ResolvedDate == null)
						.Select(s => new ActiveStateDto(s.Status, s.AssignedTime)).ToList(),
					src.Where(s => s.ResolvedDate != null)
						.Select(s => new HistoryStateDto(s.Status, s.AssignedTime, s.ResolvedDate!.Value)).ToList())
				: new SeparatedStates());
		
		config.NewConfig<Pet, PetInListDto>()
			.Map(dest => dest.Image, src => src.Images);

		config.NewConfig<Gender, string>()
	        .Map(dest => dest, src => src.Value);

        config.NewConfig<string, Gender>()
	        .MapWith(src => Gender.List.Select(g => g.Value).Contains(src)
		        ? Gender.FromValue(src)
		        : Gender.Unknown);

		config.NewConfig<string, Gender?>()
	        .MapWith(src => !IsNullOrEmpty(src)
		        ? (Gender.List.Select(g => g.Value).Contains(src)
			        ? Gender.FromValue(src)
			        : Gender.Unknown)
		        : null);

		config.NewConfig<byte[], Image>()
			.Map(dest => dest.Source, src => src);

		config.NewConfig<Image, byte[]>()
			.Map(dest => dest, src => src.Source);

		config.NewConfig<List<Image>?, byte[]?>()
			.MapWith(src => src != null && src.Count > 0 ? src[0].Source : null);
	}

	private static DateTime UtcNow() => MapContext.Current.GetService<IDateTimeProvider>().UtcNow;
}
