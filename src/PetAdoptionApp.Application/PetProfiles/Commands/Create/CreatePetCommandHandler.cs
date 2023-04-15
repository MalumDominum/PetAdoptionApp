using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Providers;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, ErrorOr<CreatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IDateTimeProvider _dateTimeProvider;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<PetColor> _petColorRepository;
	private readonly IRepository<Breed> _breedRepository;

	public CreatePetCommandHandler(IMapper mapper, IDateTimeProvider dateTimeProvider,
		IRepository<PetProfile> petRepository, IRepository<PetColor> petColorRepository, IRepository<Breed> breedRepository)
	{
		_mapper = mapper;
		_dateTimeProvider = dateTimeProvider;
		_petRepository = petRepository;
		_petColorRepository = petColorRepository;
		_breedRepository = breedRepository;
	}

	public async Task<ErrorOr<CreatePetCommandResult>> Handle(CreatePetCommand command, CancellationToken cancellationToken)
	{
		if (command.Details.BreedId != null)
			if (!await _breedRepository.AnyAsync(
				    new AnyBreedBySpeciesIdSpec(command.SpeciesId, command.Details.BreedId.Value), cancellationToken))
				return Errors.PetProfile.BreedNotBelongToSpecies;

		var petProfile = _mapper.Map<PetProfile>(command);
		petProfile.CreatedAt = _dateTimeProvider.UtcNow;
		
		var createdPet = await _petRepository.AddAsync(petProfile, cancellationToken);

		if (command.ColorIds != null)
			await _petColorRepository.AddRangeAsync(
				command.ColorIds.Select(id => new PetColor(createdPet.Id, id)), cancellationToken);

		return _mapper.Map<CreatePetCommandResult>(createdPet);
	}
}
