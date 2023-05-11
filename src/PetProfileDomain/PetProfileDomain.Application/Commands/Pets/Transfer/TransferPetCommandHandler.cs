using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Entities;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Commands.Pets.Transfer;

public class TransferPetCommandHandler : IRequestHandler<TransferPetCommand, ErrorOr<TransferPetCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Pet> _petRepository;

	#region Constructor

	public TransferPetCommandHandler(IMapper mapper, IRepository<Pet> petRepository)
	{
		_petRepository = petRepository;
		_mapper = mapper;
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
		pet.TransferHistory.Add(_mapper.Map<TransferFact>(command));

		await _petRepository.UpdateAsync(pet, cancellationToken);
		return new TransferPetCommandResult();
	}
}
