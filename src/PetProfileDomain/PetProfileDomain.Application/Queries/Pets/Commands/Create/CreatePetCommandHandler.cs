using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.BreedAggregate.Specifications;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Queries.Pets.Commands.Create;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, ErrorOr<CreatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IRepository<Pet> _petRepository;
	private readonly IRepository<Breed> _breedRepository;

	#region Constructor

	public CreatePetCommandHandler(IMapper mapper, IRepository<Pet> petRepository,
		IRepository<Breed> breedRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_breedRepository = breedRepository;
	}

	#endregion

	public async Task<ErrorOr<CreatePetCommandResult>> Handle(
		CreatePetCommand command, CancellationToken cancellationToken)
	{
		if (command.Details.BreedId != null)
			if (!await _breedRepository.AnyAsync(
				    new AnyBreedBySpeciesIdSpec(command.SpeciesId, command.Details.BreedId.Value), cancellationToken))
				return Errors.Pet.BreedNotBelongToSpecies;

		var pet = _mapper.Map<Pet>(command);

		var createdPet = await _petRepository.AddAsync(pet, cancellationToken);

		return _mapper.Map<CreatePetCommandResult>(createdPet);
	}
}
