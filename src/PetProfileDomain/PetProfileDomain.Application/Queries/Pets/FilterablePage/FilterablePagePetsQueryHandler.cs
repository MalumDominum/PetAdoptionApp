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

namespace PetProfileDomain.Application.Queries.Pets.FilterablePage;

public class FilterablePagePetsQueryHandler
	: IRequestHandler<FilterablePagePetsQuery, ErrorOr<FilterablePagePetsQueryResult>>
{
	private readonly IRepository<Pet> _petRepository;

	private readonly IMapper _mapper;

	private readonly IConfiguration _configuration;

	public FilterablePagePetsQueryHandler(IRepository<Pet> petRepository,
		IMapper mapper, IConfiguration configuration)
	{
		_petRepository = petRepository;
		_mapper = mapper;
		_configuration = configuration;
	}

	public async Task<ErrorOr<FilterablePagePetsQueryResult>> Handle(
		FilterablePagePetsQuery query, CancellationToken cancellationToken)
	{
		var pageLimit = _configuration.GetValue<int>("Pagination:PageLimit");
		var specification = new PetFilterPaginationSpec(query.Filtering, query.PageNumber, pageLimit);
		var result = await _petRepository.ListAsync(specification, cancellationToken);

		var rowsCount = await _petRepository.CountAsync(new PetFilterSpec(query.Filtering), cancellationToken);
		return result.Count > 0
			? new FilterablePagePetsQueryResult(
				_mapper.Map<List<PetInListDto>>(result),
				PaginationExtensions.GetPaginationDetails(query.PageNumber, pageLimit, rowsCount, query.Request))
			: Errors.Pet.NoFurtherRecordsError;
	}
}
