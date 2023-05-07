using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

namespace PetProfileDomain.Application.Queries.Pets.FilterablePage;

public record FilterablePagePetsQuery(
		int? Page,
		PetFilteringValues Filtering
	) : IRequest<ErrorOr<FilterablePagePetsQueryResult>>
{
	public HttpRequest Request { get; set; } = null!;

	public FilterablePagePetsQuery() : this(null, null!) { }
}
