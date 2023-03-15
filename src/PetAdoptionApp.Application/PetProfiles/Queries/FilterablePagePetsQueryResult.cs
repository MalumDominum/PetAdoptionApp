using PetAdoptionApp.Application.Common;

namespace PetAdoptionApp.Application.PetProfiles.Queries;

public record FilterablePagePetsQueryResult(
	List<PetProfileListDto> Results,
	PaginationDetails Pagination);
