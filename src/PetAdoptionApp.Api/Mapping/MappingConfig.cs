using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Create;
using PetAdoptionApp.Application.PetProfiles.Commands.Update;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using PetAdoptionApp.SharedKernel.Providers;
using static System.String;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PagePetProfileRequest, FilterablePagePetsQuery>()
	        .Map(dest => dest.Filtering, src => src);

        config.NewConfig<CreatePetCommand, PetProfile>()
	        .Map(dest => dest.SetColors, src => src.ColorIds)
	        .AfterMapping(p =>
	        {
		        p.CreatedAt = UtcNow();
				if (p.States is { Count: > 0 })
					p.StatesChangedAt = UtcNow();
	        });

        config.NewConfig<UpdatePetCommand, PetProfile>()
	        .Map(dest => dest.SetColors, src => src.ColorIds)
	        .AfterMapping(p => p.EditedAt = UtcNow());

		config.NewConfig<PetProfile, PetProfileInListDto>()
	        .Map(dest => dest.ActiveStates, src => src.States);

		config.NewConfig<List<int>?, List<PetColor>?>()
			.MapWith(src => src != null
				? src.Select(colorId => new PetColor(colorId)).ToList()
				: null);

		config.NewConfig<List<ushort>?, List<State>?>()
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
	}

	private static DateTime UtcNow() => MapContext.Current.GetService<IDateTimeProvider>().UtcNow;
}
