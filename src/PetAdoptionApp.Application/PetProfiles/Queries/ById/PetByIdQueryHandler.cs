using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Queries.ById;

public class PetByIdQueryHandler
	: IRequestHandler<PetByIdQuery, ErrorOr<PetByIdQueryResult>>
{
	private readonly IRepository<PetProfile> _petRepository;

	private readonly IMapper _mapper;

	public PetByIdQueryHandler(IRepository<PetProfile> petRepository, IMapper mapper)
	{
		_petRepository = petRepository;
		_mapper = mapper;
	}

	public async Task<ErrorOr<PetByIdQueryResult>> Handle(
		PetByIdQuery query, CancellationToken cancellationToken)
	{
		var specification = new PetProfileByIdSpec(query.Id);
		var result = await _petRepository.FirstOrDefaultAsync(specification, cancellationToken);

		return result != null
			? new PetByIdQueryResult(_mapper.Map<DetailedPetProfileDto>(result))
			: Errors.PetProfile.NoSuchRecordFoundError;
	}
}
