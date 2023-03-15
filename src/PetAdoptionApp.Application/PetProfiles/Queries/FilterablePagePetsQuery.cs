using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.PetProfiles.Queries;

public record FilterablePagePetsQuery(DateTime StatusChangedDateTime)
	: IRequest<ErrorOr<FilterablePagePetsQueryResult>>;
