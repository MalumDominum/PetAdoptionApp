using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, ErrorOr<CreatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<PetColor> _petColorRepository;

	public CreatePetCommandHandler(IMapper mapper, IRepository<PetProfile> petRepository, IRepository<PetColor> petColorRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_petColorRepository = petColorRepository;
	}

	public async Task<ErrorOr<CreatePetCommandResult>> Handle(CreatePetCommand command, CancellationToken cancellationToken)
	{
		var createdPet = await _petRepository.AddAsync(_mapper.Map<PetProfile>(command), cancellationToken);
		
		if (command.ColorIds != null)
			foreach (var colorId in command.ColorIds)
				await _petColorRepository.AddAsync(new PetColor(createdPet.Id, colorId), cancellationToken);

		return new CreatePetCommandResult(command.Name, command.Gender);
	}
}
