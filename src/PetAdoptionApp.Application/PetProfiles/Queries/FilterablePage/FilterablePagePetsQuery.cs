using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

public record FilterablePagePetsQuery(
		DateTime? FromTime,
		PetProfileFilteringValues Filtering
	) : IRequest<ErrorOr<FilterablePagePetsQueryResult>>
{
	public HttpRequest Request { get; set; } = null!;

	public FilterablePagePetsQuery() : this(null, null!) { }
}
