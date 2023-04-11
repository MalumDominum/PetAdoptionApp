using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<UpdatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<PetColor> _petColorRepository;

	public UpdatePetCommandHandler(IMapper mapper, IRepository<PetProfile> petRepository, IRepository<PetColor> petColorRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_petColorRepository = petColorRepository;
	}

	public async Task<ErrorOr<UpdatePetCommandResult>> Handle(UpdatePetCommand command, CancellationToken cancellationToken)
	{
		await _petRepository.UpdateAsync(_mapper.Map<PetProfile>(command), cancellationToken);

		var currentColorIds = await _petColorRepository
			.ListAsync(new PetColorByPetProfileIdSpec(command.Id), cancellationToken);
		
		var colorIdsToDelete = command.ColorIds != null
			? currentColorIds.Where(pc => !command.ColorIds.Contains(pc.ColorId))
			: currentColorIds;

		await _petColorRepository.DeleteRangeAsync(colorIdsToDelete, cancellationToken);

		if (command.ColorIds != null)
			await _petColorRepository.AddRangeAsync(
				command.ColorIds.Where(cId => !currentColorIds.Select(pc => pc.ColorId).Contains(cId))
					.Select(id => new PetColor(command.Id, id)), cancellationToken);

		return _mapper.Map<UpdatePetCommandResult>(command);
	}
}
