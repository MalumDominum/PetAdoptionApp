using ErrorOr;
using MassTransit;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Events;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Commands.Pets.Delete;

public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, ErrorOr<DeletePetCommandResult>>
{
	private readonly IRepository<Pet> _petRepository;
	private readonly IPublishEndpoint _publishEndpoint;

	public DeletePetCommandHandler(IRepository<Pet> petRepository, IPublishEndpoint publishEndpoint)
	{
		_petRepository = petRepository;
		_publishEndpoint = publishEndpoint;
	}

	public async Task<ErrorOr<DeletePetCommandResult>> Handle(DeletePetCommand command, CancellationToken cancellationToken)
	{
		var pet = await _petRepository.GetByIdAsync(command.PetId, cancellationToken);

		if (pet == null) return Errors.Pet.NoSuchRecordFoundError;

		await _publishEndpoint.Publish(
			new PetDeletingEvent(command.PetId), cancellationToken);

		await _petRepository.DeleteAsync(pet, cancellationToken);
		return new DeletePetCommandResult();
	}
}
