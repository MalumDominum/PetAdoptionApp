using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Pets.Commands.Delete;

public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, ErrorOr<DeletePetCommandResult>>
{
	private readonly IRepository<Pet> _petRepository;

	public DeletePetCommandHandler(IRepository<Pet> petRepository)
	{
		_petRepository = petRepository;
	}

	public async Task<ErrorOr<DeletePetCommandResult>> Handle(DeletePetCommand command, CancellationToken cancellationToken)
	{
		var pet = await _petRepository.GetByIdAsync(command.PetId, cancellationToken);

		if (pet == null)
			return Errors.Pet.NoSuchRecordFoundError;

		await _petRepository.DeleteAsync(pet, cancellationToken);
		return new DeletePetCommandResult();
	}
}
