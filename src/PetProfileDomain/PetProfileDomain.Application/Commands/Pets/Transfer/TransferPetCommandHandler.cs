using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Commands.Pets.Transfer;

public class TransferPetCommandHandler : IRequestHandler<TransferPetCommand, ErrorOr<TransferPetCommandResult>>
{
	private readonly IRepository<Pet> _petRepository;

	#region Constructor

	public TransferPetCommandHandler(IMapper mapper, IRepository<Pet> petRepository,
		IRepository<Breed> breedRepository)
	{
		_petRepository = petRepository;
	}

	#endregion

	public async Task<ErrorOr<TransferPetCommandResult>> Handle(
		TransferPetCommand command, CancellationToken cancellationToken)
	{
		var pet = await _petRepository.SingleOrDefaultAsync(
			new PetByIdSpec(command.PetId), cancellationToken);

		if (pet == null) return Errors.Pet.NoSuchRecordFoundError;

		if (pet.OwnerId != command.OldOwnerId) return Errors.Pet.NotPetOwnerError;

		// TODO Check if NewOwner exists, send confirmation mail to OldOwner
		pet.OwnerId = command.NewOwnerId;

		await _petRepository.UpdateAsync(pet, cancellationToken);
		return new TransferPetCommandResult();
	}
}
