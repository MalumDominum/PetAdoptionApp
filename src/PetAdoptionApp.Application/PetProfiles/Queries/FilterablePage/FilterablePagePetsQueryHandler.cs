﻿using System.Collections.Specialized;
using System.Web;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
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

	private readonly IConfiguration _configuration;

	public FilterablePagePetsQueryHandler(IRepository<PetProfile> petRepository,
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
		var specification = new PetProfileFilterPaginationSpec(query.Filtering, query.Page, pageLimit);
		var result = await _petRepository.ListAsync(specification, cancellationToken);

		return result.Count > 0
			? new FilterablePagePetsQueryResult(
				_mapper.Map<List<PetProfileInListDto>>(result),
				await GetPaginationDetails(query, pageLimit))
			: Errors.PetProfile.NoFurtherRecordsError;
	}

	private async Task<PaginationDetails> GetPaginationDetails(FilterablePagePetsQuery query, int pageLimit)
	{
		var rowsCount = await _petRepository.CountAsync(new PetProfileFilterSpec(query.Filtering));
		var pageCount = (int)Math.Ceiling((double)rowsCount / pageLimit);
		var currentPage = query.Page ?? 1;
		
		var uriBuilder = new UriBuilder
		{
			Scheme = query.Request.Scheme,
			Host = query.Request.Host.Host,
			Port = query.Request.Host.Port ?? 80,
			Path = $"{query.Request.Path.Value?.TrimEnd('/')}/{query.Request.PathBase.Value?.TrimStart('/')}"
		};
		var queryParameters = HttpUtility.ParseQueryString(query.Request.QueryString.ToString());
		
		var pages = new Pages(
			First: BuildPageUri(null, queryParameters, uriBuilder),
			BeforePreviousPage: currentPage > 2
				? BuildPageUri(currentPage - 2, queryParameters, uriBuilder)
				: null,
			PreviousPage: currentPage > 1
				? BuildPageUri(currentPage - 1, queryParameters, uriBuilder)
				: null,
			NextPage: currentPage < pageCount
				? BuildPageUri(currentPage + 1, queryParameters, uriBuilder)
				: null,
			AfterNextPage: currentPage < pageCount - 1
				? BuildPageUri(currentPage + 2, queryParameters, uriBuilder)
				: null,
			LastPage: pageCount > 1
				? BuildPageUri(pageCount, queryParameters, uriBuilder)
				: null
		);

		return new PaginationDetails(currentPage, pageCount, rowsCount, pages);
	}

	private static Uri BuildPageUri(int? pageNumber, NameValueCollection queryParameters, UriBuilder uriBuilder)
	{
		if (pageNumber != null)
			queryParameters.Set("Page", pageNumber.ToString());
		else
			queryParameters.Remove("Page");
		return new UriBuilder(uriBuilder.Uri) { Query = queryParameters.ToString() }.Uri;
	}
}
