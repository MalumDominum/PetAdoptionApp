using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Application.Pets.Queries.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Pets.Queries.ById;

public class PetByIdQueryHandler
	: IRequestHandler<PetByIdQuery, ErrorOr<PetByIdQueryResult>>
{
	private readonly IRepository<Pet> _petRepository;

	private readonly IMapper _mapper;

	public PetByIdQueryHandler(IRepository<Pet> petRepository, IMapper mapper)
	{
		_petRepository = petRepository;
		_mapper = mapper;
	}

	public async Task<ErrorOr<PetByIdQueryResult>> Handle(
		PetByIdQuery query, CancellationToken cancellationToken)
	{
		var specification = new PetByIdSpec(query.Id);
		var result = await _petRepository.FirstOrDefaultAsync(specification, cancellationToken);

		return result != null
			? new PetByIdQueryResult(_mapper.Map<DetailedPetDto>(result))
			: Errors.Pet.NoSuchRecordFoundError;
	}
}
