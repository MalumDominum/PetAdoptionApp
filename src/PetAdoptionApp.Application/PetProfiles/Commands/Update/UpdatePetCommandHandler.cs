using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Providers;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<UpdatePetCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IDateTimeProvider _dateTimeProvider;

	private readonly IRepository<PetProfile> _petRepository;
	private readonly IRepository<PetColor> _petColorRepository;

	public UpdatePetCommandHandler(IMapper mapper, IDateTimeProvider dateTimeProvider,
		IRepository<PetProfile> petRepository, IRepository<PetColor> petColorRepository)
	{
		_mapper = mapper;
		_petRepository = petRepository;
		_petColorRepository = petColorRepository;
		_dateTimeProvider = dateTimeProvider;
	}

	public async Task<ErrorOr<UpdatePetCommandResult>> Handle(UpdatePetCommand command, CancellationToken cancellationToken)
	{
		var petProfile = _mapper.Map<PetProfile>(command);
		petProfile.EditedAt = _dateTimeProvider.UtcNow;

		await _petRepository.UpdateAsync(petProfile, cancellationToken);

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
