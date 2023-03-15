using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandHandler : IRequestHandler<PetProfileCommand, ErrorOr<PetProfileCommandResult>>
{
	private readonly IRepository<PetProfile> _petRepository;

	public CreatePetCommandHandler(IRepository<PetProfile> petRepository)
	{
		_petRepository = petRepository;
	}

	public async Task<ErrorOr<PetProfileCommandResult>> Handle(PetProfileCommand command, CancellationToken cancellationToken)
	{
		await _petRepository.AddAsync(new PetProfile { Name = command.Name, Gender = command.Gender }, cancellationToken);

		return new PetProfileCommandResult(command.Name, command.Gender);
	}
}
