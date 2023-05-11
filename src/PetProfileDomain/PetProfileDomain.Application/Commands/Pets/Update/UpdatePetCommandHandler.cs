using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Providers;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.BreedAggregate.Specifications;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;
using PetProfileDomain.Domain.Aggregates.StateAggregate;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Commands.Pets.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<UpdatePetCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IDateTimeProvider _dateTimeProvider;

	private readonly IRepository<Pet> _petRepository;
	private readonly IRepository<Breed> _breedRepository;
	private readonly IRepository<PetColor> _petColorRepository;
	private readonly IRepository<State> _stateRepository;

	#region Constructor

	public UpdatePetCommandHandler(IMapper mapper, IDateTimeProvider dateTimeProvider,
		IRepository<Pet> petRepository, IRepository<Breed> breedRepository,
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
				return Errors.Pet.BreedNotBelongToSpeciesError;

		var pet = await _petRepository.SingleOrDefaultAsync(
			new PetForUpdateSpec(command.Id), cancellationToken);

		if (pet == null)
			return Errors.Pet.NoSuchRecordFoundError;

		if (pet.OwnerId != command.OwnerId) return Errors.Pet.NotPetOwnerError;

		var existingColors = pet.PetColors?.ToList();
		var newColors = command.ColorIds?.Select(cId => new PetColor(cId)).ToList();
		var colorsToAdd = newColors?.Except(existingColors ?? new()).ToList();
		var colorsToDelete = existingColors?.Except(newColors ?? new()).ToList();

		var existingActiveStates = pet.States?.Where(s => s.ResolvedDate == null).ToList();
		var newStates = command.States?.Select(s => new State(s, _dateTimeProvider.UtcNow)).ToList();
		var statesToAdd = newStates?.Except(existingActiveStates ?? new()).ToList();
		var statesToDelete = existingActiveStates?.Except(newStates ?? new()).ToList();

		_mapper.From(command).AdaptTo(pet);

		pet.PetColors = command.ColorIds is { Count: > 0 } ? colorsToAdd : null;
		if (colorsToDelete is { Count: > 0 })
			await _petColorRepository.DeleteRangeAsync(colorsToDelete, cancellationToken);


		if (statesToAdd is { Count: > 0 })
		{
			pet.States = statesToAdd;
			pet.NewStatesAddedAt = _dateTimeProvider.UtcNow;
		}
		else pet.States = null;

		if ((statesToDelete?.Count ?? 0) == (existingActiveStates?.Count ?? 0) && (statesToAdd?.Count ?? 0) == 0)
			pet.NewStatesAddedAt = null;
		if (statesToDelete is { Count: > 0 })
			await _stateRepository.DeleteRangeAsync(statesToDelete, cancellationToken);

		await _petRepository.UpdateAsync(pet, cancellationToken);

		return new UpdatePetCommandResult();
	}
}
