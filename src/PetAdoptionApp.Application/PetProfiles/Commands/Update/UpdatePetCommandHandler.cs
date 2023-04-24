using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Providers;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<UpdatePetCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IDateTimeProvider _dateTimeProvider;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<Breed> _breedRepository;
	private readonly IRepository<PetColor> _petColorRepository;
	private readonly IRepository<State> _stateRepository;

	#region Constructor

	public UpdatePetCommandHandler(IMapper mapper, IDateTimeProvider dateTimeProvider,
		IRepository<PetProfile> petRepository, IRepository<Breed> breedRepository,
		IRepository<PetColor> petColorRepository, IRepository<State> stateRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_breedRepository = breedRepository;
		_petColorRepository = petColorRepository;
		_stateRepository = stateRepository;
		_dateTimeProvider = dateTimeProvider;
	}

	#endregion

	public async Task<ErrorOr<UpdatePetCommandResult>> Handle(
		UpdatePetCommand command, CancellationToken cancellationToken)
	{
		if (command.Details.BreedId != null)
			if (!await _breedRepository.AnyAsync(
				    new AnyBreedBySpeciesIdSpec(command.SpeciesId, command.Details.BreedId.Value), cancellationToken))
				return Errors.PetProfile.BreedNotBelongToSpecies;

		var petProfile = await _petRepository.FirstOrDefaultAsync(
			new PetProfileForUpdateSpec(command.Id), cancellationToken);

		if (petProfile == null)
			return Errors.PetProfile.NoSuchRecordFoundError;

		var existingColors = petProfile.PetColors?.ToList();
		var newColors = command.ColorIds?.Select(cId => new PetColor(cId)).ToList();
		var colorsToAdd = newColors?.Except(existingColors ?? new()).ToList();
		var colorsToDelete = existingColors?.Except(newColors ?? new()).ToList();

		var existingActiveStates = petProfile.States?.Where(s => s.ResolvedDate == null).ToList();
		var newStates = command.States?.Select(s => new State(s, _dateTimeProvider.UtcNow)).ToList();
		var statesToAdd = newStates?.Except(existingActiveStates ?? new()).ToList();
		var statesToDelete = existingActiveStates?.Except(newStates ?? new()).ToList();

		_mapper.From(command).AdaptTo(petProfile);
		
		petProfile.PetColors = command.ColorIds is { Count: > 0 } ? colorsToAdd : null;
		if (colorsToDelete is { Count: > 0 })
			await _petColorRepository.DeleteRangeAsync(colorsToDelete, cancellationToken);


		if (statesToAdd is { Count: > 0 })
		{
			petProfile.States = statesToAdd;
			petProfile.NewStatesAddedAt = _dateTimeProvider.UtcNow;
		}
		else petProfile.States = null;

		if ((statesToDelete?.Count ?? 0) == (existingActiveStates?.Count ?? 0) && (statesToAdd?.Count ?? 0) == 0)
			petProfile.NewStatesAddedAt = null;
		if (statesToDelete is { Count: > 0 })
			await _stateRepository.DeleteRangeAsync(statesToDelete, cancellationToken);
		
		await _petRepository.UpdateAsync(petProfile, cancellationToken);

		return new UpdatePetCommandResult();
	}
}
