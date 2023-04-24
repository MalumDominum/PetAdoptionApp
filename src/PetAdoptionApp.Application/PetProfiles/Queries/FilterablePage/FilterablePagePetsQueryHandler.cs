using System.Collections.Specialized;
using System.Web;
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
		var specification = new PetProfileFilterPaginationSpec(query.FromTime, query.Filtering);
		var result = await _petRepository.ListAsync(specification, cancellationToken);

		return result.Count > 0
			? new FilterablePagePetsQueryResult(
				_mapper.Map<List<PetProfileInListDto>>(result),
				await GetPaginationDetails(query))
			: Errors.PetProfile.NoFurtherRecordsError;
	}

	private async Task<PaginationDetails> GetPaginationDetails(FilterablePagePetsQuery query)
	{
		const int pageLimit = 20; // TODO Configure PageLimit in appsettings.json

		var rowsCount = await _petRepository.CountAsync(new PetProfileFilterSpec(query.Filtering));
		var pageCount = (int)Math.Ceiling((double)rowsCount / pageLimit);

		var currentPage = query.FromTime != null
			? (int)Math.Ceiling((double)await _petRepository.CountAsync(
				new PetProfileFilterFromSpec(query.FromTime.Value, query.Filtering)) / pageLimit)
			: 1;
		
		var uriBuilder = new UriBuilder
		{
			Scheme = query.Request.Scheme,
			Host = query.Request.Host.Host,
			Port = query.Request.Host.Port ?? 80,
			Path = $"{query.Request.Path.Value?.TrimEnd('/')}/{query.Request.PathBase.Value?.TrimStart('/')}"
		};

		// Build the URI path with filtering query parameters
		var queryParameters = HttpUtility.ParseQueryString(query.Request.QueryString.ToString());
		
		var pages = new Pages(
			First: new UriBuilder(uriBuilder.Uri)
				{ Path = query.Request.Path, Query = queryParameters.ToString() }.Uri,
			BeforePreviousPage: currentPage > 2
				? BuildPageUri(queryParameters, uriBuilder, query.Request.Path)
				: null,
			PreviousPage: currentPage > 1
				? BuildPageUri(queryParameters, uriBuilder, query.Request.Path)
				: null,
			NextPage: currentPage < pageCount
				? BuildPageUri(queryParameters, uriBuilder, query.Request.Path)
				: null,
			AfterNextPage: currentPage < pageCount - 1
				? BuildPageUri(queryParameters, uriBuilder, query.Request.Path)
				: null,
			LastPage: new UriBuilder(uriBuilder.Uri)
				{ Path = query.Request.Path, Query = queryParameters.ToString() }.Uri
		);

		return new PaginationDetails(currentPage, pageCount, rowsCount, pages);
	}

	private static Uri BuildPageUri(NameValueCollection queryParameters, UriBuilder uriBuilder, string path)
	{
		queryParameters.Set("FromTime", null);
		var pageUriBuilder = new UriBuilder(uriBuilder.Uri) { Path = path, Query = queryParameters.ToString() };
		return pageUriBuilder.Uri;
	}
}
