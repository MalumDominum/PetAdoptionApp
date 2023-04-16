using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using PetAdoptionApp.Domain.Aggregates.StateAggregate.Specifications;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<UpdatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<Breed> _breedRepository;
	private readonly IRepository<PetColor> _petColorRepository;
	private readonly IRepository<State> _stateRepository;

	#region Constructor

	public UpdatePetCommandHandler(IMapper mapper, IRepository<PetProfile> petRepository,
		IRepository<Breed> breedRepository, IRepository<PetColor> petColorRepository,
		IRepository<State> stateRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_breedRepository = breedRepository;
		_petColorRepository = petColorRepository;
		_stateRepository = stateRepository;
	}

	#endregion

	public async Task<ErrorOr<UpdatePetCommandResult>> Handle(
		UpdatePetCommand command, CancellationToken cancellationToken)
	{
		if (command.Details.BreedId != null)
			if (!await _breedRepository.AnyAsync(
				    new AnyBreedBySpeciesIdSpec(command.SpeciesId, command.Details.BreedId.Value), cancellationToken))
				return Errors.PetProfile.BreedNotBelongToSpecies;

		var previousColors = await _petColorRepository.ListAsync(
			new PetColorByPetProfileIdSpec(command.Id), cancellationToken);
		await _petColorRepository.DeleteRangeAsync(previousColors, cancellationToken);

		var previousActiveStates = await _stateRepository.ListAsync(
			new ActiveStatesByPetProfileIdSpec(command.Id), cancellationToken);
		await _stateRepository.DeleteRangeAsync(previousActiveStates, cancellationToken);

		var petProfile = _mapper.Map<PetProfile>(command);

		await _petRepository.UpdateAsync(petProfile, cancellationToken);

		return new UpdatePetCommandResult();
	}
}
