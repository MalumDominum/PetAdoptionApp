using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Pagination.Extensions;
using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;
using PetProfileDomain.Domain.Errors;

namespace PetProfileDomain.Application.Queries.Pets.OwnedBy;

public class PetsOwnedByQueryHandler
	: IRequestHandler<PetsOwnedByQuery, ErrorOr<PetsOwnedByQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IConfiguration _configuration;
	private readonly IRepository<Pet> _petRepository;

	#region Constructor

	public PetsOwnedByQueryHandler(IRepository<Pet> petRepository, IMapper mapper, IConfiguration configuration)
	{
		_petRepository = petRepository;
		_mapper = mapper;
		_configuration = configuration;
	}

	#endregion

	public async Task<ErrorOr<PetsOwnedByQueryResult>> Handle(
		PetsOwnedByQuery query, CancellationToken cancellationToken)
	{
		var pageLimit = _configuration.GetValue<int>("Pagination:PageLimit");
		var specification = new PetsByOwnerWithPaginationIdSpec(
			query.PageNumber, pageLimit, query.OwnerId);
		var result = await _petRepository.ListAsync(specification, cancellationToken);

		var rowsCount = await _petRepository.CountAsync(specification, cancellationToken);
		return result.Count > 0
			? new PetsOwnedByQueryResult(
				_mapper.Map<List<PetInListDto>>(result),
				PaginationExtensions.GetPaginationDetails(query.PageNumber, pageLimit, rowsCount, query.Request))
			: Errors.Pet.NoFurtherRecordsError;
	}
}
