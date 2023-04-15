using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate.Specifications;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Delete;

public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, ErrorOr<DeletePetCommandResult>>
{
	private readonly IRepository<PetProfile> _petRepository;

	public DeletePetCommandHandler(IRepository<PetProfile> petRepository)
	{
		_petRepository = petRepository;
	}

	public async Task<ErrorOr<DeletePetCommandResult>> Handle(DeletePetCommand command, CancellationToken cancellationToken)
	{
		var petProfile = await _petRepository.GetByIdAsync(command.PetProfileId, cancellationToken);

		if (petProfile == null)
			return Errors.PetProfile.NoSuchRecordFoundError;

		await _petRepository.DeleteAsync(petProfile, cancellationToken);
		return new DeletePetCommandResult();
	}
}
