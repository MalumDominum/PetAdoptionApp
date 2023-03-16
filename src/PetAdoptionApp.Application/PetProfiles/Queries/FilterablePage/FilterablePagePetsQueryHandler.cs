using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;
using PetAdoptionApp.Domain.Errors;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

public class FilterablePagePetsQueryHandler
	: IRequestHandler<FilterablePagePetsQuery, ErrorOr<FilterablePagePetsQueryResult>>
{
	private readonly IRepository<PetProfile> _petRepository;

	private readonly IMapper _mapper;

	public FilterablePagePetsQueryHandler(IRepository<PetProfile> petRepository, IMapper mapper)
	{
		_petRepository = petRepository;
		_mapper = mapper;
	}

	public async Task<ErrorOr<FilterablePagePetsQueryResult>> Handle(
		FilterablePagePetsQuery query, CancellationToken cancellationToken)
	{
		var specification = new PetProfilePaginationSpec(new DateTime());
		var result = await _petRepository.ListAsync(specification, cancellationToken);

		return result.Count > 0
			? new FilterablePagePetsQueryResult(_mapper.Map<List<PetProfileListDto>>(result),
				new PaginationDetails(0, 0, 0, new Pages(new Uri("http://x/"), new Uri("http://x/"), new Uri("http://x/"), new Uri("http://x/"), new Uri("http://x/"), new Uri("http://x/"))))
			: Errors.PetProfile.NoFurtherRecordsError;
	}
}
