using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;

namespace PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

public record FilterablePagePetsQueryResult(
	List<PetProfileListDto> Results,
	PaginationDetails Pagination);
