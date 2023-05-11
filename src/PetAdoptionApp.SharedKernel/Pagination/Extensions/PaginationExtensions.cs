using System.Collections.Specialized;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace PetAdoptionApp.SharedKernel.Pagination.Extensions;

public static class PaginationExtensions
{
	public static PaginationDetails GetPaginationDetails(int? pageNumber, int pageLimit, int rowsCount, HttpRequest request)
	{
		var pageCount = (int)Math.Ceiling((double)rowsCount / pageLimit);
		var currentPage = pageNumber ?? 1;

		var uriBuilder = new UriBuilder
		{
			Scheme = request.Scheme,
			Host = request.Host.Host,
			Port = request.Host.Port ?? 80,
			Path = $"{request.Path.Value?.TrimEnd('/')}/{request.PathBase.Value?.TrimStart('/')}"
		};
		var queryParameters = HttpUtility.ParseQueryString(request.QueryString.ToString());

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
			queryParameters.Set("PageNumber", pageNumber.ToString());
		else
			queryParameters.Remove("PageNumber");
		return new UriBuilder(uriBuilder.Uri) { Query = queryParameters.ToString() }.Uri;
	}
}
