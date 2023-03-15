using ErrorOr;
using MediatR;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;

namespace PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

public record FilterablePagePetsQuery(
		DateTime? FromTime,
		PetProfileFilteringOptions Filtering
		) : IRequest<ErrorOr<FilterablePagePetsQueryResult>>;
